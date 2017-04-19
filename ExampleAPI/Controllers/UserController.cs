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
        private ITokenService TokenService = new TokenMockService();

        // POST: api/User
        public IHttpActionResult Post(User User)
        {
            try
            {
                User SystemUser = UserService.GetUserById(User.UserId);
                if (SystemUser == null) return NotFound();

                User.Token = this.TokenService.GetToken(User.UserId);

                return Ok(User);
            }
            catch (Exception)
            {
                //Habría que logear...
                return InternalServerError();
            }
        }
    }
}
