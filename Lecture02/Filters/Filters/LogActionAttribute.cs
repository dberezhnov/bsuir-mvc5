using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Filters.Filters
{
    public class LogActionAttribute : LogFilterAttribute, IActionFilter
    {
        public LogActionAttribute(string message) : base(message) { }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"<div>Action {Message} - OnActionExecuted</div>");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"<div>Action {Message} - OnActionExecuting</div>");
        }
    }
}