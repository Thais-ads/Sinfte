using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SinFTE.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SinFTE.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }


        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registeruser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var user = new IdentityUser
            { 
                UserName = registeruser.Email,
                Email = registeruser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registeruser.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            await _signInManager.SignInAsync(user, false);

            return Ok(await GerarJwt(registeruser.Email));
        }





        [HttpPost("Alterar-senha")]
        public async Task<ActionResult> AlterarSenha(ChangePasswordUserViewModel changePassword)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var user = await _userManager.FindByEmailAsync(changePassword.Email);

            var result = await _userManager.ChangePasswordAsync(user, changePassword.AtualPassword, changePassword.NewPassword);

            if (!result.Succeeded) return BadRequest(result.Errors);

            await _signInManager.SignInAsync(user, false);

            return Ok();
        }

        [HttpPost("entrar")]

        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if(result.Succeeded)
            {
                await GerarJwt(loginUser.Email);
                return Ok();
            }

            return BadRequest("Usuário ou senha inválidos");
        }

        private async Task<string> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encrypterToken = tokenHandler.WriteToken(token);

            HttpContext.Response.Cookies.Append("token", encrypterToken,
                new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(1),
                    HttpOnly = true,
                    Secure = true,
                    IsEssential = true,
                    SameSite = SameSiteMode.None
                });

            return encrypterToken;

        }
    }
}
