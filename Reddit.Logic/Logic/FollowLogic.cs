using Reddit.Logic.ILogic;
using Rettit.DAL.IRepository;
using Rettit.Models;

namespace Reddit.Logic.Logic
{
    public class FollowLogic : IFollowLogic
    {
        private readonly IFollowRepository _followRepository;

        public FollowLogic(IFollowRepository followRepository) 
        {
            _followRepository = followRepository;
        }

        public bool AddFollow(Follow follow) => _followRepository.AddFollow(follow);

        public bool FollowExists(Follow follow) => _followRepository.FollowExists(follow);

        public bool RemoveFollow(Follow follow) => _followRepository.RemoveFollow(follow);
    }
}
