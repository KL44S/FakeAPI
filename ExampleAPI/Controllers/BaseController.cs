using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using Services.Abstractions;
using Services.Implementations;

namespace ExampleAPI.Controllers
{
    public class BaseController : ApiController
    {
        protected String GetCurrentUserCuit()
        {
            String CurrentUserCuit = (String)(ActionContext.ActionArguments[Constants.Constants.CurrentUserCuitKey]);

            return CurrentUserCuit;
        }

        protected Boolean UserHasRol(int RoleId)
        {
            IUserService UserService = new UserService();
            String CurrentUserCuit = this.GetCurrentUserCuit();
            User User = UserService.GetUserByCuit(CurrentUserCuit);

            return User.RoleId.Equals(RoleId);
        }
    }
}
