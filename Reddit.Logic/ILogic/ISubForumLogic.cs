using Rettit.Models;
using System.Collections.Generic;

namespace Reddit.Logic.ILogic
{
    public interface ISubForumLogic
    {
        bool CreateSubForum(SubForum subForum);
        bool SubforumExists(SubForum subForum);
        IEnumerable<SubForum> GetSubForums();
        public SubForum GetSubForum(string name);
    }
} 
