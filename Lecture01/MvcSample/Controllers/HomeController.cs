using System;
using System.Linq;
using IOFile = System.IO.File;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult B(char c)
        {
            try
            {
                string[] list = IOFile.ReadAllLines(Server.MapPath("~/App_Data/countries.txt")).Where(x => x[0] == c).ToArray();
                return Content(list[(new Random()).Next(list.Length)]);
            }
            catch
            {
                return View("Error");
            }
        }
    }
}