using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.Models;

namespace AuthenticationService.Repository
{
    public class AuthRepository : IAuthRepository
    {
        //Define a private variable to represent AuthDbContext
        private readonly AuthDbContext _context;
        public AuthRepository(AuthDbContext dbContext)
        {
            _context = dbContext;
        }

        //This methos should be used to Create a new User
        public bool CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        //This methos should be used to check the existence of user
        public bool IsUserExists(string userId)
        {
            var _user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if(_user == null)
            {
                return false;
            }
            return true;
        }

        //This methos should be used to Login a user
        public bool LoginUser(User user)
        {
            var _user = _context.Users.FirstOrDefault(u => u.UserId == user.UserId && u.Password == user.Password);
            if(_user == null)
            {
                return false;
            }
            return true;
        }
    }
}
