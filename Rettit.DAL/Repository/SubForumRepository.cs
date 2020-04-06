using Rettit.DAL.IRepository;
using Rettit.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rettit.DAL.Repository
{
    public class SubForumRepository : ISubForumRepository
    {
        private readonly Context _context;

        public SubForumRepository(Context context) 
        {
            _context = context;
        }

        public bool CreateSubForum(SubForum subForum) 
        {
            try
            {
                _context.SubForum.Add(subForum);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }           
        }

        public bool SubforumExists(SubForum subForum)
        {
            if (_context.SubForum.Any(o => o.Name == subForum.Name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<SubForum> GetSubForums() => _context.SubForum;

        public SubForum GetSubForum(long id) 
        {
            var subForum = _context.SubForum.Find(id);
            return subForum;
        }
    }
}
