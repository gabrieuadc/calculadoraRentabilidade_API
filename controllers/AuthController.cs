using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using prodrentapi.Models;

namespace prodrentapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioModel model)
        {
            if (model == null)
            {
                return BadRequest("deu ruim");
            }

            if (model.Nome == "usuario" && model.Senha == "senha")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("lFqtMwdMXz0Q0qlwXhUPtFhf+B11ahhfhxLi5PBsbRo="));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Nome),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var tokeOptions = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
