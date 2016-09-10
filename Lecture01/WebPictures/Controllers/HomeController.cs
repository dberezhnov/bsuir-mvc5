using System.IO;
using System.Web.Mvc;

namespace WebPictures.Controllers
{
    public class HomeController : Controller
    {
        private static int pictures = 0;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendPicture()
        {
            if (Request.Files.Count > 0 && Request.Files[0].ContentType.StartsWith("image"))
            {
                var picture = Request.Files[0];
                picture.SaveAs(Server.MapPath($"~/App_Data/SentImage{++pictures:D3}{Path.GetExtension(picture.FileName)}"));
            }
            else
            {
                Response.Status = "400 Bad Request";
            }
            return new EmptyResult();
        }
    }
}