using ExampleAPI.Models;
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
    public class AsignacionesController : BaseController
    {
        private IRequirementUserService _requirementUserService = new RequirementUserService();
        private MappingService<User, UserViewModel> _userMappingService = new UserMappingService();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int obra)
        {
            try
            {
                //TODO: filtrar por usuario
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
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Put(int obra, String cuit)
        {
            try
            {
                if (!this.UserHasRol(Constants.Constants.AdminRoleId))
                    return Unauthorized();

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
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
