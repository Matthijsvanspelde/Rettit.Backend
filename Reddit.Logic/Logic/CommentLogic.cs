using Reddit.Logic.ILogic;
using Rettit.DAL;
using Rettit.Models;
using System;

namespace Reddit.Logic.Logic
{
    public class CommentLogic : ICommentLogic
    {
        private readonly Context _context;

        public CommentLogic(Context context)
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
