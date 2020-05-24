using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rettit.DAL;
using Rettit.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rettit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly Context _context;

        public FollowController(Context context)
        {
            _context = context;
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
        public async Task<ActionResult<Follow>> PostFollow(Follow follow)
        {
            _context.Follow.Add(follow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFollow", new { id = follow.Id }, follow);
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
    }
}
