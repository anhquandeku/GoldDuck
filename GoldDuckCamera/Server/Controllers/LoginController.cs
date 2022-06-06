
using GoldDuckCamera.Server.AppDbContext;
using GoldDuckCamera.Server.Models;
using GoldDuckCamera.Shared.Authentication;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoldDuckCamera.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IConfiguration configuration;
        public readonly SignInManager<Account> signInManager;
        public readonly UserManager<Account> userManager;
        public LoginController(IConfiguration configuration, SignInManager<Account> signInManager, UserManager<Account> userManager)
        {
            this.configuration = configuration;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var user = userManager.Users.FirstOrDefault(x => x.UserName == login.UserName);
            if (user == null)
            {
                return BadRequest(new LoginResponse { Success = false, Error = "Account is invalid" });
            }
            else
            {
                var flag = await userManager.CheckPasswordAsync(user, login.Password);
                if (!flag) return BadRequest(new LoginResponse { Success = false, Error = "Account is invalid" });
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, login.UserName),
                    new Claim(ClaimTypes.Role, user.Permission),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiry = DateTime.Now.AddDays(Convert.ToInt32(configuration["JwtExpiryInDays"]));
                var token = new JwtSecurityToken(
                    configuration["JwtIssuer"],
                    configuration["JwtAudience"],
                    claims,
                    expires: expiry,
                    signingCredentials: creds 
                );
                return Ok(new LoginResponse { Success = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

        }
    }
}
