using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reddit.Logic.ILogic;
using Rettit.Models;

namespace Rettit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISubForumLogic _subForumLogic;

        public SearchController(ISubForumLogic subForumLogic)
        {
            _subForumLogic = subForumLogic;
        }

        // GET: api/Search/name
        // Get subforums based on searchterm
        [HttpGet("{name}")]
        public ActionResult<IEnumerable<SubForum>> GetSubForum(string name)
        {
            var subForum = _subForumLogic.GetSearchedSubForum(name).ToList();

            if (subForum == null)
            {
                return NotFound();
            }

            return subForum;
        }
    }
}