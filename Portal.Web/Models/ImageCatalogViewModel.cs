using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Portal.Web.Models
{
    public class ImageCatalogViewModule
    {
        private string baseFolder;
        public ImageCatalogViewModule(string baseFolder)
        {
            this.baseFolder = baseFolder;
        }
        public List<PortalImage> Images(string tags = null)
        {
            return new ImageCatalog(baseFolder).Fetch().ToList();
        }
    }
    public class ImageCatalog
    {
        private string baseFolder;
        public ImageCatalog(string baseFolder)
        {
            this.baseFolder = baseFolder;
        }
        public IEnumerable<PortalImage> Fetch()
        {
            var images = Directory.GetFiles(Path.Combine(baseFolder), "*.png").Where(x => !x.Contains("thumb")).Select(x => new FileInfo(x).Name.Replace(".png", ""));
            return
               images.Select(x => new PortalImage() { Name = x, Tags = "aaaa,bdsadsa,casdasd" });
        }
    }
    public class PortalImage
    {
        public string Name { get; set; }
        public string Tags { get; set; }
    }
}