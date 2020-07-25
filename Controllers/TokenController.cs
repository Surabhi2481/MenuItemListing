using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuItemListing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
//using ServiceStack;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace MenuItemListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;
        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public IActionResult Login([FromBody] Authenticate login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
        private string GenerateJSONWebToken(Authenticate userInfo)
        {
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private Authenticate AuthenticateUser(Authenticate login)
        {
            Authenticate user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.Name == "Surabhi")
            {
                user = new Authenticate { Name = "Surabhi", Password = "surabhi" };
            }
            return user;
        }
    }
}
