using Exceptions;
using Services.Abstractions;
using Services.Implementations;
using System;
using System.Collections.Generic;
using Model;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ExampleAPI.Filters;

namespace ExampleAPI.Controllers
{
    [AuthFilter]
    public class AccionesController : BaseController
    {
        private IRoleActionService _roleActionService;

        public AccionesController()
        {
            this._roleActionService = new RoleActionService();
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get()
        {
            try
            {
                User User = this.GetCurrentUser();
                IEnumerable<int> Actions = this._roleActionService.GetAllActionsFromUser(User);

                return Ok(Actions);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
