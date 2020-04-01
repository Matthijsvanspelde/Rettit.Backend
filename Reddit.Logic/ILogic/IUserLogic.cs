using Rettit.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reddit.Logic
{
    public interface IUserLogic
    {
        bool AddUser(User user);
        bool UsernameExists(User user);
        IEnumerable<User> GetUser();
        User AuthenticateUser(User user);
    }
}
