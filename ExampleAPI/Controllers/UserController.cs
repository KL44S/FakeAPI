using ExampleAPI.Services;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace ExampleAPI.Controllers
{
    public class UserController : ApiController
    {
        private ITokenService TokenService = new TokenMockService();
        private static IList<User> _users = new List<User>()
        {
            new User()
            {
                cuit = "12345678",
                name = "Juan",
                lastname = "Perez",
                password = "12345678",
                idRol = 1,
                obras = new List<int>()
                {
                    1556,
                    1557,
                    1558,
                    1559
                }
            },
            new User()
            {
                cuit = "12345678910",
                name = "Alguien",
                lastname = "Mas",
                password = "12345678",
                idRol = 2,
                obras = new List<int>()
                {
                    1556,
                    1558
                }
            },
            new User()
            {
                cuit = "6346634",
                name = "Agustin",
                lastname = "Binci",
                password = "12345678",
                idRol = 2,
                obras = new List<int>()
                {
                    1557,
                }
            },
            new User()
            {
                cuit = "755433",
                name = "Guido",
                lastname = "Armando",
                password = "12345678",
                idRol = 3,
                obras = new List<int>()
                {
                    1556,
                }
            }
        };


        // POST: api/User
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post(User User)
        {
            try
            {
                var headers = Request.Headers;

                var user = _users.FirstOrDefault(x => x.cuit.Equals(User.cuit) && x.password.Equals(User.password));

                if (user != null)
                    return Ok(new { token = "untoken", user = user });

                return NotFound();
            }
            catch (Exception)
            {
                //Habría que logear...
                return InternalServerError();
            }
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int? rolId, int? requirement)
        {
            try
            {
                if (rolId != null && rolId > 0 && requirement != null && requirement > 0)
                {
                    var result = _users.FirstOrDefault(x => x.idRol.Equals(rolId) && x.obras.Contains((int)requirement));

                    if (result != null)
                        return Ok(result);

                    return NotFound();
                }

                if (rolId != null && rolId > 0)
                    return Ok(_users.Where(x => x.idRol.Equals(rolId)).ToList());

                if (requirement != null && requirement > 0)
                    return Ok(_users.Where(x => x.obras.Contains((int)requirement)).ToList());

                return Ok(_users);
            }
            catch (Exception)
            {
                //Habría que logear...
                return InternalServerError();
            }
        }
    }
}