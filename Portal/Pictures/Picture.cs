using Portal.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Images
{
    public class Picture
    {
        public string Name { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
