using System.Web.Mvc;
using Portal.Articles;

namespace Portal.Web.Models
{
    public class ArticlePageViewModel
    {
        public ArticlePageViewModel() { }
        public ArticlePageViewModel(Article article)
        {
            Id = article.Id;
            Title = article.Title;
            Content = article.Content;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public Comment Comments { get; set; }
        public Article Article()
        {
            return new Article(id: Id, title: Title, content: Content);
        }

        public ArticlePage Page()
        {
            return new ArticlePage()
            {
                Article = Article()
            };
        }
    }
}