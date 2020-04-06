using Rettit.Models;
using System.Collections.Generic;

namespace Reddit.Logic
{
    public interface IUserLogic
    {
        bool AddUser(User user);
        bool UsernameExists(User user);
        IEnumerable<User> GetUsers();
        User AuthenticateUser(User user);
    }
}
