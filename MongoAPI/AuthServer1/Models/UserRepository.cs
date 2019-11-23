using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer1.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public User FindUserById(string UserId)
        {
            var _user = _context.Users.FirstOrDefault(u => u.UserId == UserId);
            return _user;
        }

        public User Login(string userId, string password)
        {
            var _user = _context.Users.FirstOrDefault(u => u.UserId == userId && u.Password == password);
            return _user;
        }

        public User Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
