using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult A(int a, int b)
        {
            try
            {
                return Content(string.Join(" ", Enumerable.Repeat("|", a / b)));
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult B()
        {
            return View();
        }
    }
}