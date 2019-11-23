using AuthenticationService.Exceptions;
using AuthenticationService.Models;
using AuthenticationService.Repository;
using System;

namespace AuthenticationService.Service
{
    public class AuthService : IAuthService
    {
        //define a private variable to represent repository
        private readonly IAuthRepository _repo;
        //Use constructor Injection to inject all required dependencies.

        public AuthService(IAuthRepository authRepository)
        {
            _repo = authRepository;
        }

        //This methos should be used to register a new user
        public bool RegisterUser(User user)
        {
            
            if (!_repo.IsUserExists(user.UserId))
            {
                return _repo.CreateUser(user);
            }
            else
            {
                throw new UserAlreadyExistsException($"This userId {user.UserId} already in use");
            }
        }

        //This method should be used to login for existing user
        public bool LoginUser(User user)
        {
            return _repo.LoginUser(user);         
        }
    }
}
