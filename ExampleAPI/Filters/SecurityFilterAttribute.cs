using ExampleAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Model;

namespace ExampleAPI.Filters
{
    public class SecurityFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            String Token = String.Empty;

            try
            {
                Token = actionContext.Request.Headers.GetValues(Statics.Statics.AuthenticationHeader).FirstOrDefault();
                if (String.IsNullOrEmpty(Token)) throw new HttpResponseException(HttpStatusCode.Unauthorized);

                String UserId = TokenService.GetUserId(Token);
                if (String.IsNullOrEmpty(UserId)) throw new HttpResponseException(HttpStatusCode.Unauthorized);

                User User = UserService.GetUserById(UserId);
                if (User == null) throw new HttpResponseException(HttpStatusCode.Unauthorized);

                base.OnActionExecuting(actionContext);
            }
            catch(InvalidOperationException)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

        }
    }
}