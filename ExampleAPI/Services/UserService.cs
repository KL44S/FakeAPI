using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;

namespace ExampleAPI.Services
{
    public static class UserService
    {
        public static User GetUserById(String UserId)
        {
            //User UserResult = Statics.Statics.Users.FirstOrDefault(User => User.UserId.Equals(UserId));
            User User = new User();
            return User;
        }
    }
}