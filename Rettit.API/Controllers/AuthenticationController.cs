using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reddit.Logic;
using Rettit.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Rettit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public AuthenticationController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
      
        [HttpPost]
        public ActionResult<User> AuthenticateUser(User user)
        {
            var myUser = _userLogic.AuthenticateUser(user);
            if (myUser != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier, myUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, myUser.Username)
                }),
                    Issuer = "https://localhost:44339",
                    Audience = "https://localhost:44339",
                    Expires = DateTime.Now.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("A-VERY-STRONG-KEY-HERE")), SecurityAlgorithms.HmacSha512Signature),
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(new
                {
                    token = tokenHandler.WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            else
            {
                return StatusCode(401);
            }
        }      
    }
}
