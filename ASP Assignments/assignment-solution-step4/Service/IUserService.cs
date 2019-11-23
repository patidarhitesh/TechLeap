﻿using Entities;

namespace Service
{
    /*
    * Should not modify this interface. You have to implement these methods in
    * corresponding Impl classes
    */
    public interface IUserService
    {
        bool RegisterUser(User user);
        bool UpdateUser(string userId,User user);
        User GetUserById(string userId);
        bool ValidateUser(string userId, string password);
        bool DeleteUser(string userId);
    }
}
