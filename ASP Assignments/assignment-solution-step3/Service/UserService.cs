using DAL;
using Entities;
using Exceptions;

namespace Service
{
        /*
      * Service classes are used here to implement additional business logic/validation
      * */
    public class UserService : IUserService
    {
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
                throw new UserNotFoundException($"User with id: {userId} does not exist");
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
                throw new UserNotFoundException($"User with id: {userId} does not exist");
            }
        }

        //This method should be used to save a new user.
        public bool RegisterUser(User user)
        {
            var user1 = userRepo.GetUserById(user.UserId);
            if (user1 == null)
            {
                return userRepo.RegisterUser(user);
            }
            else
            {
                throw new UserAlreadyExistException($"This userid: {user.UserId} already exists");
            }
        }

        //This method should be used to update an existing user.
        public bool UpdateUser(string userId,User user)
        {
            var user1 = userRepo.GetUserById(userId);

            if (user1 != null)
            {
                return userRepo.UpdateUser(user1);
            }
            else
            {
                throw new UserNotFoundException($"User with id: {userId} does not exist");
            }
        }

        //This method should be used to validate a user using userId and password.
        public bool ValidateUser(string userId, string password)
        {
            
            if (userRepo.ValidateUser(userId, password))
            {
                return true;
            }
            else
            {
                throw new UserNotFoundException($"User with id: {userId} does not exist");
            }
        }
    }
}
