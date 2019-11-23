using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer1.Models;
//using AuthServer1.Exceptions;

namespace AuthServer1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }
        public User Login(string userId, string password)
        {
            var user = _repo.Login(userId, password);
            if(user != null)
            {
                return user;
            }
            else
            {
                throw new UserNotFoundException("Invalid user id or password");
            }
        }

        public User RegisterUser(User userDetails)
        {
            var user = _repo.FindUserById(userDetails.UserId);
            if(user == null)
            {
                return _repo.Register(userDetails);
            }
            else
            {
                throw new UserAlreadyExistsException($"User Id {userDetails.UserId} already exists");
            }
        }
    }
}
