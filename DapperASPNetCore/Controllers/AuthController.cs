using DapperASPNetCore.Contracts;
//using DapperASPNetCore.Context;
using DapperASPNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DapperASPNetCore.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private readonly DapperContext _context;

        //public AuthController(DapperContext context) => _context = context;
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Geçersiz sunucu isteği");
            }

            var dbUser = await _authRepo.GetUser(user);
            if (user.UserName == dbUser?.UserName && user.Password == dbUser?.Password)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                    {
                        new Claim("UserName", user.UserName),
                        new Claim("Password", user.Password),
                        //new Claim(ClaimTypes.Role, "Manager"),
                    };

                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44336",
                    audience: "https://localhost:44336",
                    //claims: new List<Claim>(),
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}
