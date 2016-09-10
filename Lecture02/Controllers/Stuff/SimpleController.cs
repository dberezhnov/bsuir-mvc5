using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Controllers.Stuff
{
    public class SimpleController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.Url.ToString().EndsWith("/ActionString"))
            {
                requestContext.HttpContext.Response.ContentType = "text/html";
                requestContext.HttpContext.Response.Write($@"<!DOCTYPE html>
<html>
<head>
    <title>Simple HTML</title>
</head>
<body style=""background: cyan"">
    Hello {requestContext.HttpContext.Request.QueryString["q"]}
</body>
</html>
");
            }
            else if (requestContext.HttpContext.Request.Url.ToString().EndsWith("/ActionPicture"))
            {
                requestContext.HttpContext.Response.ContentType = "image/png";
                requestContext.HttpContext.Response.WriteFile(requestContext.HttpContext.Server.MapPath("~/Content/netmvc.png"));
            }
        }
    }
}