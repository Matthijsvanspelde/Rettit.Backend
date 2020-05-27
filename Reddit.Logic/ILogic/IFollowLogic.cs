using Rettit.Models;

namespace Reddit.Logic.ILogic
{
    public interface IFollowLogic
    {
        bool AddFollow(Follow follow);
        bool FollowExists(Follow follow);
        bool RemoveFollow(Follow follow);
    }
}
