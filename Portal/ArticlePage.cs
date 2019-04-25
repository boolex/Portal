using System.Collections.Generic;
namespace Portal.Articles
{
    public class Page
    {
        public List<string> KeyWords { get; protected set; }
        public string UrlName { get; protected set; }
    }
    public class ArticlePage : Page
    {
        public Article Article { get; protected set; }       

    }
}
