using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters.Filters;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        [ErrorCatcher]
        public ActionResult MakeError()
        {
            throw new AccessViolationException("Denied");
        }

        [NewSessionCatcher, ActionName("time")]
        public ActionResult TimeSinceLastRequest(DateTime last) => View(DateTime.Now - last);

        [ThreeInOneFilter]
        public ActionResult Divide(int a, int b) => View(Tuple.Create(a, b, a / b, a % b));

        [LogException("A", Order = 15), LogResult("B", Order = 5), LogAuthentication("C", Order = 14), LogAction("D", Order = 13),
         LogAuthentication("E", Order = 1), LogAction("F", Order = 7), LogAuthorization("G", Order = 3),
         LogException("H", Order = 6), LogResult("I", Order = 9), LogAuthorization("J", Order = 2), LogAction("K", Order = 4),
         LogResult("L", Order = 10), LogAuthorization("M", Order = 8), LogAuthentication("N", Order = 12), LogAction("O", Order = 11)]
        public void FilterOrder()
        {
            Response.Write("<div>Action method executed</div>");
            //throw new Exception();
        }
    }
}