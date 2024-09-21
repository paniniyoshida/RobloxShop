using RobloxShop.Entities;
using RobloxShop.Repository.Interfaces;
using RobloxShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
           _userRepository = userRepository;
        }

        public User Add(User entity)
        {
            entity.Birthday = entity.Birthday.ToUniversalTime();
            return _userRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User? GetByLoginAndPassword(string username, string password)
        {
            return _userRepository.GetAll().FirstOrDefault(u => u.Login == username && u.PasswordHash == password);
        }

        public User Update(User entity)
        {
            return _userRepository.Update(entity);
        }

        
    }
}
