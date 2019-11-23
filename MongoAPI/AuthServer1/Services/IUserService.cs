using AuthServer1.Models;

namespace AuthServer1.Services
{
    public interface IUserService
    {
        User RegisterUser(User user);
        User Login(string userId, string password);
    }
}
