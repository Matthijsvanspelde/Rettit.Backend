using Rettit.DAL.IRepository;
using Rettit.Models;
using System;

namespace Rettit.DAL.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly Context _context;

        public CommentRepository(Context context)
        {
            _context = context;
        }

        public bool AddComment(Comment comment) 
        {
            try
            {
                _context.Comment.Add(comment);
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
