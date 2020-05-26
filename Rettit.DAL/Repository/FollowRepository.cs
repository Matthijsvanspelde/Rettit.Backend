using Rettit.DAL.IRepository;
using Rettit.Models;
using System;
using System.Linq;

namespace Rettit.DAL.Repository
{
    public class FollowRepository : IFollowRepository
    {
        private readonly Context _context;

        public FollowRepository(Context context) 
        {
            _context = context;
        }

        public bool AddFollow(Follow follow)
        {
            try
            {
                _context.Follow.Add(follow);
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool DeleteFollow(Follow follow) 
        { 
        
        }

        public bool FollowExists(Follow follow) 
        {
            return _context.Follow.Any(e => e.UserId == follow.UserId && e.SubForumId == follow.SubForumId);
        }
    }
}
