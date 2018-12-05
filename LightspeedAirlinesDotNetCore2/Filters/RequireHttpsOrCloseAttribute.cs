using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LightspeedAirlinesDotNetCore2.Filters
{
    // This class is added to the Filters list.
    // Purpose: Instead of redirection of HTTP request to HTTPS automatically, this filter will return error code 400 Bad Request.
    // After adding it to the Filters list, app.UseHttpsRedirection(); can be removed from the configure method in Startup.cs Class.

public class RequireHttpsOrCloseAttribute : RequireHttpsAttribute
    {
        protected override void HandleNonHttpsRequest(AuthorizationFilterContext filterContext)
        {
            filterContext.Result = new StatusCodeResult(400);
        }
    }
}
