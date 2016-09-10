using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Filters.Filters
{
    public class LogAuthorizationAttribute : LogFilterAttribute, IAuthorizationFilter
    {
        public LogAuthorizationAttribute(string message) : base(message) { }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"<div>Authorization {Message} - OnAuthorization</div>");
        }
    }
}