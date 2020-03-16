using Rettit.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rettit.DAL
{
    public interface IUserContext
    {
        public User AddUser(User user);
        public IEnumerable<User> GetUser();
    }
}
