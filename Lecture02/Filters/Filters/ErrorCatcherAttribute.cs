using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Filters.Filters
{
    public class ErrorCatcherAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new ContentResult
                { Content = $"There was an error of type {filterContext.Exception.GetType().Name} in action {filterContext.RouteData.Values["action"]}: {filterContext.Exception.Message}", ContentType = "text/plain" };
            filterContext.ExceptionHandled = true;
        }
    }
}