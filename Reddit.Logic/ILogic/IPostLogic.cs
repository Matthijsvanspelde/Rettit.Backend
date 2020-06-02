using Rettit.Models;
using System.Collections.Generic;

namespace Reddit.Logic.ILogic
{
    public interface IPostLogic
    {
        bool AddPost(Post post);
        IEnumerable<Post> GetPosts(long SubForumId);
    }
}
 