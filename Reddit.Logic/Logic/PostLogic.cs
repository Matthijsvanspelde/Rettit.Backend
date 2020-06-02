using Microsoft.EntityFrameworkCore;
using Reddit.Logic.ILogic;
using Rettit.DAL;
using Rettit.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reddit.Logic.Logic
{
    public class PostLogic : IPostLogic
    {
        private readonly Context _context;

        public PostLogic(Context context)
        {
            _context = context;
        }

        public bool AddPost(Post post)
        {
            try
            {
                _context.Post.Add(post);
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Post> GetPosts(long SubForumId)
        {
            return _context.Post
                .Where(c => c.SubForumId == SubForumId)
                .Include(c => c.Comments)
                .ThenInclude(c => c.User)
                .ToList();
        }
    }
}
