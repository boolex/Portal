using Portal.Articles;
namespace Portal
{
    public class ArticleResource
    {
        public Article Article { get; protected set; }
        public Page Page { get; protected set; }
        public Social Social { get; protected set; }
    }
}
