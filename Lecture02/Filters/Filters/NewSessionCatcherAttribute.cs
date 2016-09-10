using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Filters.Filters
{
    public class NewSessionCatcherAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Session["last"] = DateTime.Now;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.IsNewSession)
            {
                filterContext.HttpContext.Session["last"] = DateTime.Now;
                filterContext.Result = new RedirectResult(filterContext.HttpContext.Request.RawUrl);
            }
        }
    }
}