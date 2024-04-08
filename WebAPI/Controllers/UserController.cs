using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult Login(string user)
        {
            var claims = new[]
            {
              new Claim("user", user),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("helloMySecretKeyThatIsLongEnaugh"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "test.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds); 
            var jwtString = new JwtSecurityTokenHandler().WriteToken(token);

            return new JsonResult(jwtString);
        }
    }
}
