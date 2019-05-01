using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Portal.Web.Controllers
{
    public class TagController : Controller
    {
        static TagCatalog tagCatalog;
        static TagController()
        {
            tagCatalog = new TagCatalog();
            tagCatalog.Load();
        }
        [HttpGet]
        public JsonResult List(string item)
        {
            return Json(new[] { "a", "b", "c" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPut]
        public JsonResult Add(string item)
        {
            tagCatalog.Add(item);
            return Json(new { });
        }
    }
    public class TagCatalog
    {
        List<string> tags;
        public TagCatalog()
        {
            tags = new List<string>();
        }
        public void Load()
        {
            using (PortalContext context = new PortalContext())
            {
            }
        }
        public void Add(string item)
        {
            if (!tags.Contains(item.ToLower()))
            {
                tags.Add(item.ToLower());
            }
        }
    }
}