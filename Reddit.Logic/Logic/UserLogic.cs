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

        public bool AddUser(User user) => _userRepository.AddUser(user);

        public bool UsernameExists(User user) => _userRepository.UsernameExists(user);

        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = _userRepository.GetUsers();
            return users;
        }

        public User AuthenticateUser(User user)
        {
            var myUser = _userRepository.AuthenticateUser(user);
            return myUser;
        }
    }
}
