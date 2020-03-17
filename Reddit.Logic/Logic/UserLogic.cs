using Rettit.DAL;
using Rettit.Models;
using System;
using System.Collections.Generic;

namespace Reddit.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AddUser(User user) 
        {
            if (user.Username.Length >= 5 && user.Password.Length >= 8)
            {
                return _userRepository.AddUser(user);                                   
            }
            else
            {
                return false;
            }                       
        }

        public bool UsernameExists(User user) => _userRepository.UsernameExists(user);

        public IEnumerable<User> GetUser()
        {
            IEnumerable<User> users = _userRepository.GetUser();
            return users;
        }

    }
}
