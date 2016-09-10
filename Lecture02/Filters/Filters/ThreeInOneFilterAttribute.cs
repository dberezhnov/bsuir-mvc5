using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Filters.Filters
{
    public class ThreeInOneFilterAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                filterContext.Result = new ViewResult { ViewName = "Oops" };
                filterContext.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.QueryString["doit"] != "yes")
            {
                filterContext.Result = new EmptyResult();
            }
            else
            {
                int junk;
                if (filterContext.ActionParameters["a"] == null ||
                    !int.TryParse(filterContext.ActionParameters["a"].ToString(), out junk)) filterContext.ActionParameters["a"] = 10;
                if (filterContext.ActionParameters["b"] == null ||
                    !int.TryParse(filterContext.ActionParameters["b"].ToString(), out junk)) filterContext.ActionParameters["b"] = 3;
            }
        }
    }
}