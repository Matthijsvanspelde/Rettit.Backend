using Rettit.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rettit.DAL
{
    public interface IUserContext
    {
        bool AddUser(User user);
        bool UsernameExists(User user);
        IEnumerable<User> GetUser();
    }
}
