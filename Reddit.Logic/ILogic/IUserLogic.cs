using Rettit.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reddit.Logic
{
    public interface IUserLogic
    {
        public User AddUser(User user);
        public IEnumerable<User> GetUser();
    }
}
