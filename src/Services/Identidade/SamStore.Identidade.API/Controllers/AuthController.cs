using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SamStore.Identidade.API.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace SamStore.Identidade.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Logar(LoginViewModel loginData)
        {
            if (!ModelState.IsValid) return BadRequest();

            SignInResult result = await _signInManager.PasswordSignInAsync(loginData.Email, loginData.Password, false, false);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
