using ExampleAPI.Filters;
using ExampleAPI.Models;
using ExampleAPI.Results;
using ExampleAPI.Services;
using ExampleAPI.ViewModel;
using Exceptions;
using Model;
using Services.Abstractions;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ExampleAPI.Controllers
{
    [AuthFilter]
    public class AsignacionesController : BaseController
    {
        private IRequirementUserService _requirementUserService = new RequirementUserService();
        private MappingService<User, UserViewModel> _userMappingService = new UserMappingService();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int obra)
        {
            try
            {
                if (obra <= 0)
                    return BadRequest();

                if (!this.IsUserAssignedToRequirement(obra))
                    return new ForbiddenActionResult(Request, "");

                IEnumerable<User> Users = this._requirementUserService.GetUsersFromRequirementNumber(obra);
                IEnumerable<UserViewModel> UserViewModels = _userMappingService.UnMapEntities(Users);

                return Ok(UserViewModels);
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

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Put(int obra, String cuit)
        {
            try
            {
                if (!this.MayCurrentUserDoAction(Constants.Constants.AssignUsersAction))
                    return new ForbiddenActionResult(Request, "");

                if (String.IsNullOrEmpty(cuit))
                    return BadRequest();

                RequirementUser RequirementUser = new RequirementUser();
                RequirementUser.Cuit = cuit;
                RequirementUser.RequirementNumber = obra;

                this._requirementUserService.SaveRequirementUser(RequirementUser);

                return Ok();
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
