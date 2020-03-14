using Rettit.DAL;
using Rettit.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reddit.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User AddUser(User user) 
        {
            _userRepository.AddUser(user);
            return user;
        }

        public IEnumerable<User> GetUser()
        {
            IEnumerable<User> users = _userRepository.GetUser();
            return users;
        }

    }
}
