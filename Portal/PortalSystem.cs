namespace Portal
{
    public class PortalSystem
    {
        private readonly IPortalServiceLocator locator;
        public PortalSystem(IPortalServiceLocator locator = null)
        {
            this.locator = locator ?? new PortalServiceLocator();
        }
        public Article ArticleGet(Article article)
        {
            return PersistentArticle(article: article).Read();
        }
        public Article ArticleSet(Article article)
        {
            return PersistentArticle(article: article).Save();
        }
        public void ArticleDelete(Article article)
        {
            PersistentArticle(article: article).Delete();
        }
        public virtual PersistentArticle PersistentArticle(Article article)
        {
            return locator.PersistentArticle(article: article);
        }
    }
}
