using Model;
using Services.Abstractions;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExampleAPI.Controllers
{
    public class BaseController : ApiController
    {
        private User _currentUser;

        public BaseController() : base()
        {
            ITokenService TokenService = new BearerTokenService();
            IUserService UserService = new UserService();

            String UnencodedToken = TokenService.GetUnencodedToken(this.ActionContext.Request.Headers.Authorization.Parameter);
            String Cuit = TokenService.GetCuitFromUnencodedToken(UnencodedToken);
            
            this._currentUser = UserService.GetUserByCuit(Cuit);
        }

        protected Boolean UserHasRol(int RoleId)
        {
            return this._currentUser.RoleId.Equals(RoleId);
        }
    }
}
