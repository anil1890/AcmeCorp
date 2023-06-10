using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AcmeCorp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthoController : ControllerBase
    {
        private readonly string _secretKey;

        public AuthoController()
        {
            // Replace with your secret key
            _secretKey = "anil.dash.anil.dash.anil.dash.anil.dash.anil.dash.anil.dash.anil.dash";
        }

        [HttpGet]
        public IActionResult GetToken()
        {
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(signingCredentials: credentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString });
        }
    }
}
