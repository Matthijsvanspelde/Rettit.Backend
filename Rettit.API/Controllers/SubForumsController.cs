using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rettit.DAL;
using Rettit.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rettit.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SubForumsController : ControllerBase
    {
        private readonly Context _context;

        public SubForumsController(Context context)
        {
            _context = context;
        }

        // GET: api/SubForums
        [HttpGet]
        public ActionResult<IEnumerable<SubForum>> GetSubForum()
        {
            return _context.SubForum.ToList();
        }

        // GET: api/SubForums/5
        [HttpGet("{id}")]
        public ActionResult<SubForum> GetSubForum(long id)
        {
            var subForum = _context.SubForum.Find(id);

            if (subForum == null)
            {
                return NotFound();
            }

            return subForum;
        }

        
        // POST: api/SubForums
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<SubForum> PostSubForum(SubForum subForum)
        {
            return Ok();
        }   
    }
}
