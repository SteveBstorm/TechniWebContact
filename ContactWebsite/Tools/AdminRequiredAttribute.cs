using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactWebsite.Tools
{
    public class AdminRequiredAttribute : TypeFilterAttribute
    {
        public AdminRequiredAttribute() : base(typeof(AdminRequiredFilter))
        {

        }
    }

    public class AdminRequiredFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (SessionManager.user is null || !SessionManager.user.IsAdmin)
            {
                context.Result = new RedirectToRouteResult(new { action = "ListUser", controller = "User" });
            }
        }
    }
}
