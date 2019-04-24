using System.Collections.Generic;
namespace Portal.Articles
{
    public class Page
    {
        public int Id { get; set; }
        public List<string> KeyWords { get; set; }
        public string UrlName { get; set; }
    }

    public class ArticlePage : Page
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
