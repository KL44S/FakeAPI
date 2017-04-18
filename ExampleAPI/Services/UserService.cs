using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleAPI.Services
{
    public static class UserService
    {
        public static User GetUserById(String UserId)
        {
            User UserResult = Statics.Statics.Users.FirstOrDefault(User => User.UserId.Equals(UserId));

            return UserResult;
        }
    }
}