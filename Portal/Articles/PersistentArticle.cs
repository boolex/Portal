using System;
namespace Portal
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class PersistentArticle : Article
    {
        protected PersistentArticle() { }
        protected PersistentArticle(Article article) : base(article) { }
        public abstract Article Read();
        public abstract Article Save();
        public abstract void Delete();
    }
}
