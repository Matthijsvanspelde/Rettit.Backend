using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
using System.Web.Http.Cors;

namespace Rettit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "http://rettit.azurewebsites.net", headers: "*", methods: "*")]
    public class PostsController : ControllerBase
    {
        private readonly Context _context;
        private readonly IPostLogic _postLogic;

        public PostsController(Context context, IPostLogic postLogic)
        {
            _context = context;
            _postLogic = postLogic;
        }

        // GET: api/Posts
        [HttpGet("{SubForumId}")]
        public ActionResult<IEnumerable<Post>> GetPost(long SubForumId)
        {
            return _postLogic.GetPosts(SubForumId).ToList();
        }

        // POST: api/Posts
        [HttpPost]
        [Authorize]
        public ActionResult<Post> PostPost(Post post)
        {
            string authHeaderValue = Request.Headers["Authorization"];
            var tokenClaims = GetClaims(authHeaderValue.Substring("Bearer ".Length).Trim());
            post.UserId = Convert.ToInt32(tokenClaims.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            post.Username = tokenClaims.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value;
            if (post.Title != null && post.Message != null)
            {
                _postLogic.AddPost(post);
                return Ok();
            }
            else
            {
                return StatusCode(422);
            }                       
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(long id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Post.Remove(post);
            await _context.SaveChangesAsync();

            return post;
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
