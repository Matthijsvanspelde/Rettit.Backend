using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Reddit.Logic.ILogic;
using Rettit.DAL;
using Rettit.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Rettit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly Context _context;
        private readonly IFollowLogic _followLogic;
        public FollowController(Context context, IFollowLogic followLogic)
        {
            _context = context;
            _followLogic = followLogic;
        }

        // GET: api/Follow
        [HttpGet]
        public ActionResult<Follow> GetFollow()
        {
            string authHeaderValue = Request.Headers["Authorization"];
            var tokenClaims = GetClaims(authHeaderValue.Substring("Bearer ".Length).Trim());
            var id = Convert.ToInt32(tokenClaims.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            var exists = _followLogic.FollowExists(id);
            return Ok(exists);
        }


        // POST: api/Follow
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public ActionResult<Follow> PostFollow([FromBody]Follow follow)
        {
            string authHeaderValue = Request.Headers["Authorization"];
            var tokenClaims = GetClaims(authHeaderValue.Substring("Bearer ".Length).Trim());
            follow.UserId = Convert.ToInt32(tokenClaims.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            if (!FollowExists(follow))
            {
                if (_followLogic.AddFollow(follow))
                {
                    return Ok("Subscribed");
                }
                else
                {
                    return StatusCode(422);
                }
            }
            else
            {
                return StatusCode(409, "Already subscribed");
            }
            
        }

        // DELETE: api/Follow/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Follow>> DeleteFollow(long id)
        {
            var follow = await _context.Follow.FindAsync(id);
            if (follow == null)
            {
                return NotFound();
            }

            _context.Follow.Remove(follow);
            await _context.SaveChangesAsync();

            return follow;
        }

        private bool FollowExists(Follow follow)
        {
            return _followLogic.FollowExists(follow);
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
