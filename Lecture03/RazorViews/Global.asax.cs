using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RazorViews
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine
            {
                PartialViewLocationFormats = new[]
                {
                    "~/Views/{1}/{0}.cshtml", "~/Views/Partials/{0}.cshtml"
                }
            });
        }

        protected void Session_Start()
        {
            Session["id"] = Guid.NewGuid();
        }

        protected void Session_End() { }
        protected void Application_End() { }
    }
}
