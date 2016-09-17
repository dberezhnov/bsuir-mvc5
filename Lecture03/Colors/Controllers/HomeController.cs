using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Colors.Infrastructure;

namespace Colors.Controllers
{
    public enum Rainbow
    {
        Red, Orange, Yellow, Lime, Cyan, Blue, Purple
    }

    public enum DeepPurple
    {
        Blue, MediumBlue, MidnightBlue, RebeccaPurple, Purple
    }

    public class HomeController : Controller
    {
        public HomeController()
        {
            ActionInvoker = new CustomActionInvoker();
        }

        public ActionResult ActionRainbow(Rainbow e) => View("Index", e);
        public ActionResult ActionDeepPurple(DeepPurple e) => View("Index", e);
    }
}