using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Filters.Filters
{
    public class LogResultAttribute : LogFilterAttribute, IResultFilter
    {
        public LogResultAttribute(string message) : base(message) { }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"<div>Result {Message} - OnResultExecuted</div>");
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"<div>Result {Message} - OnResultExecuting</div>");
        }
    }
}