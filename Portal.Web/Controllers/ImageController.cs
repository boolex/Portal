using Portal.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
namespace Portal.Web.Controllers
{
    public class ImageController : Controller
    {
        [HttpPost]
        public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> files)
        {
            var name = Guid.NewGuid();
            foreach (var file in files)
            {
                string filePath = name + Path.GetExtension(file.FileName);
                filePath = filePath.Replace("jpg", "png");
                filePath = filePath.Replace("jpeg", "png");
                file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), filePath));
                //Here you can write code for save this information in your database if you want
            }
            return Json(new { name = name });
        }
        public ActionResult View(string name)
        {
            var dir = Server.MapPath("/UploadedFiles");
            var path = Path.Combine(dir, name + ".png"); //validate the path for security or use other means to generate the path.
            return base.File(path, "image/png");
        }
        public ActionResult Thumb(string name)
        {
            int finalWidth = 300;

            string source = string.Format("{0}.png", Path.Combine(Server.MapPath("~/UploadedFiles"), name));
            var target = Path.Combine(Server.MapPath("~/UploadedFiles"), string.Format("{0}_thumb.png", name));
            if (!System.IO.File.Exists(target))
            {
                using (var image = System.Drawing.Image.FromFile(source))
                {
                    int finalHeight = (int)(image.Height / ((1.0 * image.Width) / finalWidth));
                    var thumb = image.GetThumbnailImage(finalWidth, finalHeight, () => false, IntPtr.Zero);

                    thumb.Save(target, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            return base.File(target, "image/png");
        }
        public ActionResult Index()
        {
            return View(new ImageCatalogViewModule(Server.MapPath("~/UploadedFiles")));
        }
        [HttpPost]
        public void Update(string name, Dictionary<string, string> attributes)
        {

        }
    }
}
