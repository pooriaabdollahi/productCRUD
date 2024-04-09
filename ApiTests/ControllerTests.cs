using Application;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;
using WebAPI.Controllers;

namespace ApiTests
{
    public class ControllerTests
    {
        [Fact]
        public void LoginTest()
        {
            var username = "test";
            var result  = LoginHandler.GenerateToken(username);
          
            Assert.True(ValidateToken(result, username));
        }
        private static bool ValidateToken(string? authToken,string username)
        {
            if (string.IsNullOrEmpty(authToken)) return false;
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadToken(authToken) as JwtSecurityToken;
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            if (principal != null)
            if (token?.Claims.FirstOrDefault(x => x.Type == "user")?.ToString() == username) return true;
            return false;
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false,
                ValidateAudience = false,
                ValidateIssuer = true,
                ValidIssuer = "test.com",
                ValidAudience = "api.com",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("helloMySecretKeyThatIsLongEnaugh"))
            };
        }
    }
}