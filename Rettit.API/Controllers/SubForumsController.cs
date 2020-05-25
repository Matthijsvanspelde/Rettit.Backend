using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reddit.Logic.ILogic;
using Rettit.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;

namespace Rettit.API.Controllers
{
    [Route("api/[controller]")]   
    [ApiController]
    public class SubForumsController : ControllerBase
    {
        private readonly ISubForumLogic _subForumLogic;

        public SubForumsController(ISubForumLogic subForumLogic)
        {
            _subForumLogic = subForumLogic;
        }

        // GET: api/SubForums
        [HttpGet]
        public ActionResult<IEnumerable<SubForum>> GetSubForum()
        {
            return _subForumLogic.GetSubForums().ToList();
        }

        // GET: api/SubForums/name
        [HttpGet("{name}")]
        public ActionResult<SubForum> GetSubForum(string name)
        {
            var subForum = _subForumLogic.GetSubForum(name);

            if (subForum == null)
            {
                return NotFound();
            }

            return subForum;
        }
        
        // POST: api/SubForums
        [HttpPost]
        [Authorize]
        public ActionResult<SubForum> PostSubForum(SubForum subForum)
        {
            string authHeaderValue = Request.Headers["Authorization"];
            var tokenClaims = GetClaims(authHeaderValue.Substring("Bearer ".Length).Trim());
            subForum.UserId = Convert.ToInt32(tokenClaims.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            if (subForum != null && !_subForumLogic.SubforumExists(subForum))
            {
                _subForumLogic.CreateSubForum(subForum);
                return Ok();
            }
            else
            {
                return StatusCode(422);
            }            
        }

        private ClaimsPrincipal GetClaims(string token)
        {
            var signingKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes("A-VERY-STRONG-KEY-HERE"));
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = false,
                ValidateAudience = false
            };

            return handler.ValidateToken(token, validations, out var tokenSecure);
        }
    }
}
