using System;
using System.Linq;
using Entities;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class UserRepository : IUserRepository
    {
        private readonly KeepDbContext context;
        public UserRepository(KeepDbContext dbContext)
        {
            context = dbContext;
        }

        //This method should be used to delete an existing user. 
        public bool DeleteUser(string userId)
        {
            User user = context.Users.Find(userId);
           
            context.Users.Remove(user);
            context.SaveChanges();
            return true;
        }
        //This method should be used to get a user by userId.
        public User GetUserById(string userId)
        {
            return context.Users.Find(userId);
        }
        //This method should be used to save a new user.
        public bool RegisterUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return true;
        }
        //This method should be used to update an existing user.
        public bool UpdateUser(User user)
        {
            context.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return true;
        }
        //This method should be used to validate a user using userId and password.
        public bool ValidateUser(string userId, string password)
        {
            var user = context.Users.Where(u => u.UserId == userId && u.Password == password);
            return user.Count() == 0 ? false : true;
        }
    }
}
