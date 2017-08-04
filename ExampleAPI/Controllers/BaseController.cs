using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using Services.Abstractions;
using Services.Implementations;

namespace ExampleAPI.Controllers
{
    public class BaseController : ApiController
    {
        protected String GetCurrentUserCuit()
        {
            String CurrentUserCuit = (String)(ActionContext.ActionArguments[Constants.Constants.CurrentUserCuitKey]);

            return CurrentUserCuit;
        }

        protected User GetCurrentUser()
        {
            IUserService UserService = new UserService();

            String CurrentUserCuit = this.GetCurrentUserCuit();
            User User = UserService.GetUserByCuit(CurrentUserCuit);

            return User;
        }

        protected Boolean MayCurrentUserDoAction(int ActionId)
        {
            User CurrentUser = this.GetCurrentUser();
            IRoleActionService RoleActionService = new RoleActionService();

            return RoleActionService.HasUserAction(CurrentUser, ActionId);
        }

        protected Boolean IsUserAssignedToRequirement(int RequirementNumber)
        {
            IRequirementUserService RequirementUserService = new RequirementUserService();
            String CurrentUserCuit = this.GetCurrentUserCuit();
            Boolean DoesRequirementHaveTheUser = RequirementUserService.DoesRequirementHaveTheUser(RequirementNumber, CurrentUserCuit);

            if (!DoesRequirementHaveTheUser)
            {
                IRequirementService RequirementService = new RequirementService();
                RequirementService.GetRequirementByRequirementNumber(RequirementNumber);

                return false;
            }

            return true;
        }
    }
}
