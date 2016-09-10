using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Filters.Filters
{
    public class AutomaticNewUserAttribute : FilterAttribute, IAuthenticationFilter
    {
        private static long _id = 0;

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (!filterContext.Principal.Identity.IsAuthenticated)
            {
                FormsAuthentication.SetAuthCookie($"User{++_id}", false);
                filterContext.Result = new RedirectResult(filterContext.HttpContext.Request.RawUrl, false);
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
    }
}