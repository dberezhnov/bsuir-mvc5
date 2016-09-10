using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Filters.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class LogFilterAttribute : FilterAttribute
    {
        public string Message { get; }

        public LogFilterAttribute(string message)
        {
            Message = message;
        }
    }
}