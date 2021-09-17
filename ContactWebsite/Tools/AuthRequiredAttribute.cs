using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactWebsite.Tools
{
    public class AuthRequiredAttribute : TypeFilterAttribute
    {
        public AuthRequiredAttribute() : base(typeof(AuthRequiredFilter)) { }
    }

    public class AuthRequiredFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(SessionManager.user is null)
            {
                context.Result = new RedirectToRouteResult(new { action = "Login", controller = "User" });
            }
        }
    }
}
