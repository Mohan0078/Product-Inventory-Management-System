using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductInventoryManagementSystem.Model.CommandModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductInventoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public IActionResult Post(LoginCommandModel loginCommandModel)
        {
            if (loginCommandModel == null)
                return BadRequest("Please provide valid input!");

            if (loginCommandModel.Email == "mohantest@yopmail.com" && loginCommandModel.Password == "testing")
            {
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

                var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature);

                var subject = new ClaimsIdentity(new[] {
                new Claim(JwtRegisteredClaimNames.Sub, "Mohan Patel"),
                new Claim(JwtRegisteredClaimNames.Email, loginCommandModel.Email),
                new Claim(ClaimTypes.Role, "User"),
                });

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = DateTime.UtcNow.AddHours(1),
                    Audience = audience,
                    SigningCredentials = signingCredentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                return Ok(jwtToken);
            }
            return BadRequest("Either email or password is wrong!");
        }
    }
}
