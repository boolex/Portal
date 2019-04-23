namespace Portal
{
    public class PortalServiceLocator : IPortalServiceLocator
    {
        public PersistentArticle PersistentArticle(Article article)
        {
            return new MsSqlPersistentArticle(article: article, context: PortalContext());
        }
        private PortalContext PortalContext()
        {
            return new PortalContext();
        }
    }

    public interface IPortalServiceLocator
    {
        PersistentArticle PersistentArticle(Article article);
    }
}
