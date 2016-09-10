using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Filters.Filters
{
    public class LogAuthenticationAttribute : LogFilterAttribute, IAuthenticationFilter
    {
        public LogAuthenticationAttribute(string message) : base(message) { }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"<div>Authentication {Message} - OnAuthentication</div>");
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"<div>Authentication {Message} - OnAuthenticationChallenge</div>");
        }
    }
}