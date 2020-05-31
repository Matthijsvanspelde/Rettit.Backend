using Rettit.DAL;
using Rettit.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reddit.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly Context _context;
        public UserLogic(Context context)
        {
            _context = context;
        }

        public bool AddUser(User user)
        {
            try
            {
                _context.User.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

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

        public IEnumerable<User> GetUsers() => _context.User;

        public User AuthenticateUser(User user)
        {
            var myUser = _context.User.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (myUser != null)
            {
                return myUser;
            }
            else
            {
                return null;
            }

        }
    }
}
