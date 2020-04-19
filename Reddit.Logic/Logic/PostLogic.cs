using Reddit.Logic.ILogic;
using Rettit.DAL.IRepository;
using Rettit.Models;
using System.Collections.Generic;

namespace Reddit.Logic.Logic
{
    public class PostLogic : IPostLogic
    {
        private readonly IPostRepository _postRepository;

        public PostLogic(IPostRepository postRepository) 
        {
            _postRepository = postRepository;
        }

        public bool AddPost(Post post) => _postRepository.AddPost(post);

        public IEnumerable<Post> GetPosts(long SubForumId) => _postRepository.GetPosts(SubForumId);
    }
}
