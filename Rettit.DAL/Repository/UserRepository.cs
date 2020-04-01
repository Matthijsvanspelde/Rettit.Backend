using Rettit.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rettit.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }

        public bool AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChangesAsync();
            return true;
        }

        public bool UsernameExists(User user)
        {
            if (_context.User.Any(o => o.Username == user.Username))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<User> GetUser() => _context.User;

        public User AuthenticateUser(User user)
        {
            var myUser = _context.User.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (myUser != null)    //User was found
            {
                return myUser;
            }
            else    //User was not found
            {
                return null;
            }

        }

    }
}
