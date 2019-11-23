using System;
using System.Linq;
using MongoDB.Driver;
using UserService.Models;

namespace UserService.Repository
{
    public class UserRepository:IUserRepository
    {
        //define a private variable to represent UserContext
        private readonly UserContext context;
        public UserRepository(UserContext _Context)
        {
            context = _Context;
        }

        //This method should be used to delete an existing user. 
        public bool DeleteUser(string userId)
        {
            var deleteResult = context.Users.DeleteOne(c => c.UserId == userId);
            return deleteResult.DeletedCount > 0;
        }
        //This method should be used to get a user by userId.
        public User GetUserById(string userId)
        {
            return context.Users.Find(c => c.UserId == userId).FirstOrDefault();
        }
        //This method should be used to save a new user.
        public User RegisterUser(User user)
        {
            user.AddedDate = DateTime.Now.Date;
            context.Users.InsertOne(user);
            return user;

        }
        //This method should be used to update an existing user.
        public bool UpdateUser(String UserId, User user)
        {
            var filter = Builders<User>.Filter.Where(c => c.UserId == UserId);
            var updateResult = context.Users.ReplaceOne(filter, user);
            return updateResult.MatchedCount > 0;
        }
        //This method should be used to validate a user using userId and password.

    }
}
