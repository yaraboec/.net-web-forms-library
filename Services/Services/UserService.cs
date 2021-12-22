using System.Collections.Generic;
using DataAccess.Entities;
using DataAccess.Repositories.UserRepository;
using Services.Contracts;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User Create(User user)
        {
            return _userRepository.Create(user);
        }

        public User Update(User user)
        {
            return _userRepository.Update(user);
        }

        public User Delete(string username)
        {
            return _userRepository.Delete(username);
        }
    }
}
