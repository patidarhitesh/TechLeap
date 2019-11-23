namespace AuthServer1.Models
{
    public interface IUserRepository
    {
        User FindUserById(string UserId);
        User Register(User user);
        User Login(string userId, string password);
    }
}
