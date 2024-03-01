using BlazorAppWASM.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlazorAppWASM.Server.Controllers
{

    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost("gettoken")]
        public ActionResult<string> GetToken([FromBody] User user)
        {
            var claims = new List<Claim>() { new Claim(ClaimTypes.Name, user.Login) };

            var token = new JwtSecurityToken(JwtOptions.Issuer, JwtOptions.Audience, claims, expires: DateTime.UtcNow.AddHours(1), signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(JwtOptions.GetKey(), SecurityAlgorithms.HmacSha256));

            string str = new JwtSecurityTokenHandler().WriteToken(token);
            _logger.LogInformation(str); 

            return Ok(str);
        }
    }
}
