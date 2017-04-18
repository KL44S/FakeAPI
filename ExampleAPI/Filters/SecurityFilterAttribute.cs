using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ExampleAPI.Filters
{
    public class SecurityFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //TODO: implementar seguridad con token

            base.OnActionExecuting(actionContext);
        }
    }
}