using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Filters.Filters
{
    public class LogExceptionAttribute : LogFilterAttribute, IExceptionFilter
    {
        public LogExceptionAttribute(string message) : base(message) { }

        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"<div>Exception {Message} - OnException</div>");
            filterContext.ExceptionHandled = true;
        }
    }
}