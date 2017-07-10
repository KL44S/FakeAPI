using ExampleAPI.Services;
using ExampleAPI.ViewModel;
using Services;
using Services.Abstractions;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using Model;
using System.Web.Http.Results;
using Exceptions;

namespace ExampleAPI.Controllers
{
    public class UserController : ApiController
    {
        private IUserService _userService = new UserService();
        private MappingService<User, UserViewModel> _userMappingService = new UserMappingService();

        // POST: api/User
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Post(String cuit, String password)
        {
            try
            {
                if (cuit == null || password == null)
                {
                    return BadRequest();
                }

                IEncryptionService EnctyptionService = new Sha256EncryptionService();

                String Password = EnctyptionService.Encrypt(password);

                User User = this._userService.GetUserByCuitAndPassword(cuit, Password);

                if (User != null)
                {
                    ITokenService _tokenService = new BearerTokenService();
                    String Token = _tokenService.GetEncodedToken(cuit, Password);

                    UserViewModel UserViewModel = _userMappingService.UnMapEntity(User);

                    return Ok(new { token = Token, user = UserViewModel });
                }                    

                return NotFound();
            }

            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            catch (Exception Exception)
            {
                //Habría que logear...
                return InternalServerError();
            }
        }

        private IHttpActionResult ReturnUsers(IEnumerable<User> Users)
        {
            if (Users.Count() > 0)
            {
                IEnumerable<UserViewModel> UserViewModels = _userMappingService.UnMapEntities(Users);
                return Ok(UserViewModels);
            }

            return NotFound();
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get(int? rolId, int? requirement)
        {
            try
            {
                IEnumerable<User> Users = null;

                if (rolId != null && rolId > 0 && requirement != null && requirement > 0)
                {
                    Users = this._userService.GetUsersByRoleIdAndRequirementNumber((int)rolId, (int)requirement);
                    return this.ReturnUsers(Users);
                }

                if (rolId != null && rolId > 0)
                {
                    Users = this._userService.GetUsersByRoleId((int)rolId);
                    return this.ReturnUsers(Users);
                }

                if (requirement != null && requirement > 0)
                {
                    Users = this._userService.GetUsersByRequirementNumber((int)requirement);
                    return this.ReturnUsers(Users);
                }

                Users = this._userService.GetAllUsers();
                return this.ReturnUsers(Users);

            }
            catch (Exception)
            {
                //Habría que logear...
                return InternalServerError();
            }
        }
    }
}