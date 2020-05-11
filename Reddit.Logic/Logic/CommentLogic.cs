using Reddit.Logic.ILogic;
using Rettit.DAL.IRepository;
using Rettit.Models;

namespace Reddit.Logic.Logic
{
    public class CommentLogic : ICommentLogic
    {
        private readonly ICommentRepository _commentRepository;

        public CommentLogic(ICommentRepository commentRepository) 
        {
            _commentRepository = commentRepository;
        }

        public bool AddComment(Comment comment) => _commentRepository.AddComment(comment);
    }
}
