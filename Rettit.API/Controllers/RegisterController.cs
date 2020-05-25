using Microsoft.AspNetCore.Mvc;
using Reddit.Logic;
using Rettit.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace Rettit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public RegisterController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        // GET: api/Register
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUser()
        {
            IEnumerable<User> users = _userLogic.GetUsers();
            return users.ToList();
        }

        // POST: api/Register
        [HttpPost]
        public ActionResult<User> PostUser([FromBody]User user)
        {
            if (user.Username != null && user.Password != null && !_userLogic.UsernameExists(user))
            {
                _userLogic.AddUser(user);
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            else
            {
                return StatusCode(422);
            }                                        
        }
    }
}
