using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters.Filters;

namespace Filters.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        public ActionResult TopSecret() => View();

        [AutomaticNewUser]
        public ActionResult Register() => View((object)User.Identity.Name);
    }
}