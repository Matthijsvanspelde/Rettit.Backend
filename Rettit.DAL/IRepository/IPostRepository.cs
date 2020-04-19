using Rettit.Models;
using System.Collections.Generic;

namespace Rettit.DAL.IRepository
{
    public interface IPostRepository
    {
        bool AddPost(Post post);
        IEnumerable<Post> GetPosts(long SubForumId);
    }
}
