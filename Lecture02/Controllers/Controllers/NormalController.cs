using System;
using System.Collections.Generic;
using IOFile = System.IO.File;
using System.Web.Mvc;
using Controllers.Stuff;

namespace Controllers.Controllers
{
    public class NormalController : Controller, III
    {
        #region Actions v1

        public void ActionString()
        {
            Response.ContentType = "text/html";
            Response.Write(string.Format(IOFile.ReadAllText(Server.MapPath("~/Content/result.igihtml")), Request.QueryString["q"]));
        }

        public void ActionPicture()
        {
            Response.ContentType = "image/png";
            Response.WriteFile(Server.MapPath("~/Content/netmvc.png"));
        }

        #endregion

        #region Actions v2

        public string Index2() => IOFile.ReadAllText(Server.MapPath("~/Content/form.html"));

        public string ActionString2(int q, int f) => string.Format(IOFile.ReadAllText(Server.MapPath("~/Content/result.igihtml")), q + f);

        #endregion

        #region Action Session

        public string ActionSession(DateTime? last)
        {
            DateTime current = DateTime.Now;
            Session["last"] = current;
            return string.Format(IOFile.ReadAllText(Server.MapPath("~/Content/result.igihtml")), (current - (last ?? current)).TotalMilliseconds);
        }

        #endregion

        #region Actions v3

        public ViewResult Index3() => new ViewResult();

        public RedirectResult WrongIndex() => new RedirectResult("/Normal/Index3");

        public FileResult Picture3() => new FilePathResult(Server.MapPath("~/Content/netmvc.png"), "image/png");

        public Base64PictureResult Picture3A() => new Base64PictureResult(Server.MapPath("~/Content/netmvc.png"));

        public ViewResult WithViewBag()
        {
            ViewBag.Content = "Some content";
            //return new ViewResult();
            return View();
        }

        #endregion

        #region Actions v4

        public ViewResult ActionString4(int q, int f) => View(q + f);

        #endregion

        ActionResult III.Act() => new ContentResult { Content = "Act", ContentType = "text/plain" };
    }

    public interface III
    {
        ActionResult Act();
    }
}