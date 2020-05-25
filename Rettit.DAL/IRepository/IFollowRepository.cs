using Rettit.Models;

namespace Rettit.DAL.IRepository
{
    public interface IFollowRepository
    {
        bool AddFollow(Follow follow);
    }
}
