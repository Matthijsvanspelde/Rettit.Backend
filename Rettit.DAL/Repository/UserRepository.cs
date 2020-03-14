using Microsoft.EntityFrameworkCore;
using Rettit.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rettit.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _userContext; 

        public UserRepository(IUserContext userContext) 
        {
            _userContext = userContext;
        }

        public User AddUser(User user)
        {
            _userContext.AddUser(user);
            return user;
        }

        public IEnumerable<User> GetUser()
        {
            IEnumerable<User> users = _userContext.GetUser();
            return users;
        }
    }
}
