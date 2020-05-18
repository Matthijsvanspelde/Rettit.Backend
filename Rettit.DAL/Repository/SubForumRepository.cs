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
                _context.SubForum.Add(subForum);
                _context.SaveChanges();
                return true;    
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

        public SubForum GetSubForum(string name) 
        {
            var subForum = _context.SubForum.SingleOrDefault(a => a.Name == name);
            return subForum;
        }

        public IEnumerable<SubForum> GetSearchedSubForum(string name)
        {
            return _context.SubForum
                .Where(c => c.Name.Contains(name))
                .ToList();
        }
    }
}
