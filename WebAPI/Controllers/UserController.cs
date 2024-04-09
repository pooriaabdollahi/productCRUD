using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application;
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
            return new JsonResult(LoginHandler.GenerateToken(user));
        }
    }
}
