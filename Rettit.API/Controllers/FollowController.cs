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
    [Authorize]
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
        public async Task<ActionResult<IEnumerable<Follow>>> GetFollow()
        {
            return await _context.Follow.ToListAsync();
        }

        // GET: api/Follow/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Follow>> GetFollow(long id)
        {
            var follow = await _context.Follow.FindAsync(id);

            if (follow == null)
            {
                return NotFound();
            }

            return follow;
        }

        // POST: api/Follow
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Follow> PostFollow(Follow follow)
        {
            string authHeaderValue = Request.Headers["Authorization"];
            var tokenClaims = GetClaims(authHeaderValue.Substring("Bearer ".Length).Trim());
            follow.UserId = Convert.ToInt32(tokenClaims.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            if (_followLogic.AddFollow(follow))
            {
                return Ok("Subscribed");
            }
            else
            {
                return StatusCode(422);
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

        private bool FollowExists(long id)
        {
            return _context.Follow.Any(e => e.Id == id);
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
