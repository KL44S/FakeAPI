using ExampleAPI.Services;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace ExampleAPI.Controllers
{
    public class UserController : ApiController
    {
        // POST: api/User
        public IHttpActionResult Post(User User)
        {
            try
            {
                //Acá habría que validar el usuario primero...
                String Token = TokenService.GetToken(User.UserId);

                var Response = Ok();
                Response.Request.Headers.Add(Statics.Statics.AuthenticationHeader, Token);

                return Response;
            }
            catch (Exception Exception)
            {
                return new BadRequestErrorMessageResult(Exception.Message, this);
            }
        }
    }
}
