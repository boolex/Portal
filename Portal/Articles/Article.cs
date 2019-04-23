namespace Portal
{
    public class Article
    {
        protected Article() { }
        public Article(Article article)
        {
            if (article != null)
            {
                Id = article.Id;
                Title = article.Title;
                Content = article.Content;
            }
        }
        public Article(int id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }
        public int Id { get; protected set; }
        public string Title { get; protected set; }
        public string Content { get; protected set; }
    }
}
