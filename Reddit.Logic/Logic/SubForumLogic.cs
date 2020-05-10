using Reddit.Logic.ILogic;
using Rettit.DAL.IRepository;
using Rettit.Models;
using System.Collections.Generic;

namespace Reddit.Logic.Logic
{
    public class SubForumLogic : ISubForumLogic
    {
        private readonly ISubForumRepository _subForumRepository;

        public SubForumLogic(ISubForumRepository subForumRepository) 
        {
            _subForumRepository = subForumRepository;
        }

        public bool CreateSubForum(SubForum subForum) => _subForumRepository.CreateSubForum(subForum);

        public bool SubforumExists(SubForum subForum) => _subForumRepository.SubforumExists(subForum);

        public IEnumerable<SubForum> GetSubForums() 
        {
            IEnumerable<SubForum> users = _subForumRepository.GetSubForums();
            return users;
        }

        public SubForum GetSubForum(string name)
        {
            var subForum = _subForumRepository.GetSubForum(name);
            return subForum;
        }

        public IEnumerable<SubForum> GetSearchedSubForum(string name)
        {
            var subForum = _subForumRepository.GetSearchedSubForum(name);
            return subForum;
        }
    }
}
