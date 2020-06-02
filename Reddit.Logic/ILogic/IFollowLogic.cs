using Rettit.Models;
using System.Collections.Generic;

namespace Reddit.Logic.ILogic
{
    public interface IFollowLogic
    {
        bool AddFollow(Follow follow);
        bool FollowExists(Follow follow);
        bool RemoveFollow(Follow follow);
        IEnumerable<Follow> GetSubscribedPosts(long userId);
    }
}
