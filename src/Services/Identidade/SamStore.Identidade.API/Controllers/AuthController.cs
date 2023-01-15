using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using SamStore.Identidade.API.Extensions;
using SamStore.Identidade.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace SamStore.Identidade.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentitySettings _identitySettings;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<IdentitySettings> identitySettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _identitySettings = identitySettings.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel registerData)
        {
            if(!ModelState.IsValid) return BadRequest();

            IdentityUser user = new IdentityUser()
            {
                UserName = registerData.Email,
                Email = registerData.Email,
                EmailConfirmed = true
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerData.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok(await GenerateJwt(user.Email));
            }

            return BadRequest();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Login(LoginViewModel loginData)
        {
            if (!ModelState.IsValid) return BadRequest();

            SignInResult result = await _signInManager.PasswordSignInAsync(loginData.Email, loginData.Password, false, false);

            if (result.Succeeded)
            {
                return Ok(await GenerateJwt(loginData.Email));
            }

            return BadRequest();
        }

        private async Task<UserData> GenerateJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach(var role in roles) 
            {
                claims.Add(new Claim("role", role));
            }

            ClaimsIdentity identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

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

            string encodedToken = tokenHandler.WriteToken(token);

            UserData userData = new UserData()
            {
                AccessToken = encodedToken,
                HoursToExpire = TimeSpan.FromHours(_identitySettings.HoursToExpire).TotalSeconds,
                UserToken = new UserToken()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new UserClaim() { Type = c.Type, Value = c.Value })
                }
            };

            return userData;
        }

        private static long ToUnixEpochDate(DateTime date) =>
            (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
