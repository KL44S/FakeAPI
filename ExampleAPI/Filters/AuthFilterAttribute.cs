using Services.Abstractions;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Model;

namespace ExampleAPI.Filters
{
    public class AuthFilterAttribute : AuthorizationFilterAttribute
    {
        private static String AuthorizationScheme = "Bearer";
        private static ITokenService _tokenService = new BearerTokenService();

        public override void OnAuthorization(HttpActionContext ActionContext)
        {
            var Headers = ActionContext.Request.Headers;
            if (Headers.Authorization != null && Headers.Authorization.Scheme.Equals(AuthorizationScheme))
            {
                try
                {
                    String UnencodedToken = _tokenService.GetUnencodedToken(Headers.Authorization.Parameter);
                    String Cuit = _tokenService.GetCuitFromUnencodedToken(UnencodedToken);
                    String Password = _tokenService.GetPasswordFromUnencodedToken(UnencodedToken);

                    UserService UserService = new UserService();
                    User User = UserService.GetUserByCuitAndPassword(Cuit, Password);

                    if (User == null)
                        PutUnauthorizedResult(ActionContext);

                    ActionContext.ActionArguments.Add(Constants.Constants.CurrentUserCuitKey, User.Cuit);
                }
                catch (Exception)
                {
                    PutUnauthorizedResult(ActionContext);
                }
            }
            else
            {
                PutUnauthorizedResult(ActionContext);
            }
        }

        private void PutUnauthorizedResult(HttpActionContext ActionContext)
        {
            ActionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }
}