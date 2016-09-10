using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers.Stuff
{
    public class Base64PictureResult : ActionResult
    {
        public string FileName { get; }

        public string ContentType { get; }

        public Base64PictureResult(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) throw new ArgumentException("File name cannot be empty", nameof(filename));
            FileName = filename;
            switch (System.IO.Path.GetExtension(filename).ToLower())
            {
                case ".jpg": case ".jpeg":
                    ContentType = "image/jpeg";
                    break;
                case ".png":
                    ContentType = "image/png";
                    break;
                case ".gif":
                    ContentType = "image/gif";
                    break;
                case ".bmp":
                    ContentType = "image/bmp";
                    break;
                default:
                    ContentType = "image";
                    break;
            }
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write($"data:{ContentType};base64,{Convert.ToBase64String(System.IO.File.ReadAllBytes(FileName))}");
        }
    }
}