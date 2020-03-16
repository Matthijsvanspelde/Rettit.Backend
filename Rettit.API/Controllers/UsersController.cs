using Microsoft.AspNetCore.Mvc;
using Reddit.Logic;
using Rettit.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Cors;

namespace Rettit.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin", "*", "*")]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic _userLogic;
        public UsersController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUser()
        {
            IEnumerable<User> users = _userLogic.GetUser();
            return users.ToList();
        }

        /*
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        */
        // POST: api/Users
        [HttpPost]
        public ActionResult<User> PostUser([FromBody]User user)
        {
            _userLogic.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
        /*
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(long id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(long id)
        {
            return _context.User.Any(e => e.Id == id);
        }
        */
    }
}
