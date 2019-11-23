using System;
using UserService.Exceptions;
using UserService.Models;
using UserService.Repository;

namespace UserService.Service
{
    public class UserService : IUserService
    {
        //define a private variable to represent repository

        //Use constructor Injection to inject all required dependencies.

        private readonly IUserRepository userRepo;
        /*
       Use constructor Injection to inject all required dependencies.
       */
        public UserService(IUserRepository repository)
        {
            userRepo = repository;
        }
        //This method should be used to delete an existing user. 
        public bool DeleteUser(string userId)
        {
            User user = userRepo.GetUserById(userId);

            if (user != null)
            {
                return userRepo.DeleteUser(userId);

            }
            else
            {
                throw new UserNotFoundException($"This user id does not exist");
            }
        }

        //This method should be used to get a user by userId.
        public User GetUserById(string userId)
        {
            var user1 = userRepo.GetUserById(userId);

            if (user1 != null)
            {
                return user1;
            }
            else
            {
                throw new UserNotFoundException($"This user id does not exist");
            }
        }

        //This method should be used to save a new user.
        public User RegisterUser(User user)
        {
            var user1 = userRepo.GetUserById(user.UserId);
            if (user1 == null)
            {
                return userRepo.RegisterUser(user);
            }
            else
            {
                throw new UserNotCreatedException($"This user id already exists");
            }
        }

        //This method should be used to update an existing user.
        public bool UpdateUser(string userId, User user)
        {
            var user1 = userRepo.GetUserById(userId);

            if (user1 != null)
            {
                return userRepo.UpdateUser(userId, user1);
            }
            else
            {
                throw new UserNotFoundException($"This user id does not exist");
            }
        }

    }
}
