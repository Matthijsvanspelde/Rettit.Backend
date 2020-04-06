using Rettit.Models;
using System.Collections.Generic;

namespace Rettit.DAL
{
    public interface IUserRepository
    {
        bool AddUser(User user);
        bool UsernameExists(User user);
        IEnumerable<User> GetUsers();
        User AuthenticateUser(User user);
    }
}
