using Rettit.Models;
using System.Collections.Generic;

namespace Rettit.DAL.IRepository
{
    public interface ISubForumRepository
    {
        bool CreateSubForum(SubForum subForum);
        bool SubforumExists(SubForum subForum);
        IEnumerable<SubForum> GetSubForums();
        public SubForum GetSubForum(string name);
    }
}
