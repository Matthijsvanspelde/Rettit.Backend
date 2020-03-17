using Rettit.Models;
using System.Collections.Generic;

namespace Rettit.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _userContext; 

        public UserRepository(IUserContext userContext) 
        {
            _userContext = userContext;
        }

        public bool AddUser(User user) => _userContext.AddUser(user);

        public bool UsernameExists(User user) => _userContext.UsernameExists(user);

        public IEnumerable<User> GetUser()
        {
            IEnumerable<User> users = _userContext.GetUser();
            return users;
        }
    }
}
