using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class LoginHandler
    {
        public static string GenerateToken(string user)
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
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
