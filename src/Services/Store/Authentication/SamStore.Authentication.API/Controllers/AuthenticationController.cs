﻿using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SamStore.Authentication.API.Data;
using SamStore.Authentication.API.Models;
using SamStore.Core.CQRS.Integrations;
using SamStore.Core.CQRS.Integrations.Abstractions;
using SamStore.MessageBus;
using SamStore.WebAPI.Core.API.Controllers;
using SamStore.WebAPI.Core.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using ValidationFailure = FluentValidation.Results.ValidationFailure;

namespace SamStore.Authentication.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthenticationController : CustomController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentitySettingsDTO _identitySettings;
        private readonly IdentidadeDbContext _context;
        private readonly IMessageBus _messageBus;

        public AuthenticationController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<IdentitySettingsDTO> identitySettings, IMessageBus messageBus, IdentidadeDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _identitySettings = identitySettings.Value;
            _messageBus = messageBus;
            _context = context;
        }

        /// <summary>
        /// User login
        /// </summary>
        /// <param name="loginData"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login(LoginDTO loginData)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            SignInResult result = await _signInManager.PasswordSignInAsync(loginData.Email, loginData.Password, false, false);

            if (result.Succeeded)
            {
                return CustomResponse(await GenerateJwt(loginData.Email));
            }

            if(result.IsLockedOut)
            {
                AddError("User has been blocked after too many attempts");
                return CustomResponse();
            }

            if(result.IsNotAllowed)
            {
                AddError("User not allowed");
                return CustomResponse();
            }

            AddError("Invalid email or password");
            return CustomResponse();
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="registerData"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserDataDTO), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register(RegisterUserDTO registerData)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            IdentityUser user = new IdentityUser()
            {
                UserName = registerData.Email,
                Email = registerData.Email,
                EmailConfirmed = true
            };

            using IDbContextTransaction transaction = _context.Database.BeginTransaction();

            IdentityResult result = await _userManager.CreateAsync(user, registerData.Password);

            if (result.Succeeded)
            {
                ResponseMessage customerResult = await RegisterCostumer(registerData);

                if (!customerResult.ValidationResult.IsValid)
                {
                    await transaction.RollbackAsync();
                    return CustomResponse(customerResult.ValidationResult);
                }

                await transaction.CommitAsync();
                return CustomResponse(await GenerateJwt(user.Email));
            }

            foreach (IdentityError error in result.Errors)
            {
                AddError(error.Description);
            }

            return CustomResponse();
        }

        private async Task<UserDataDTO> GenerateJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);

            ClaimsIdentity identityClaims = await GetCLaims(user, roles);
            string encodedToken = EncodeToken(identityClaims);

            UserDataDTO userData = new UserDataDTO()
            {
                AccessToken = encodedToken,
                HoursToExpire = TimeSpan.FromHours(_identitySettings.HoursToExpire).TotalSeconds,
                UserToken = new UserToken()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = identityClaims.Claims.Select(c => new UserClaim() { Type = c.Type, Value = c.Value })
                }
            };

            return userData;
        }

        private string EncodeToken(ClaimsIdentity identityClaims)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_identitySettings.Secret);

            SecurityToken token = tokenHandler.CreateToken(new SecurityTokenDescriptor()
            {
                Issuer = _identitySettings.Issuer,
                Audience = _identitySettings.Audience,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_identitySettings.HoursToExpire),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token); ;
        }

        private async Task<ClaimsIdentity> GetCLaims(IdentityUser user, IList<string> roles)
        {
            var claims = await _userManager.GetClaimsAsync(user);

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            ClaimsIdentity identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);
            return identityClaims;
        }

        private static long ToUnixEpochDate(DateTime date) =>
            (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private async Task<ResponseMessage> RegisterCostumer(RegisterUserDTO registerData)
        {
            var user = await _userManager.FindByEmailAsync(registerData.Email);

            var registeredEvent =
                new RegisteredUserIntegrationEvent(Guid.Parse(user.Id), registerData.Name, registerData.CPF, registerData.Email);

            try
            {
                ResponseMessage result = await _messageBus.RequestAsync<RegisteredUserIntegrationEvent, ResponseMessage>(registeredEvent);
                return result;
            }
            catch (Exception ex)
            {
                var result = new ValidationResult(new[] { new ValidationFailure { ErrorMessage = ex.Message } });
                return new ResponseMessage(result);
            }
        }
    }
}
