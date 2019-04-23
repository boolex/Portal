using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Portal
{ 
    public class MsSqlPersistentArticle : PersistentArticle
    {
        private readonly PortalContext context;

        protected MsSqlPersistentArticle():base() { }
        public MsSqlPersistentArticle(
            Article article,
            PortalContext context
            ) :
            base(article)
        {
            this.context = context;
        }

        public override Article Read()
        {
            return context.Articles.FirstOrDefault(x => x.Id == Current.Id);
        }

        public override Article Save()
        {
            if (Id == 0)
            {
                context.Articles.Add(Current);
            }
            else
            {
                context.Articles.Attach(Current);
            }
            context.SaveChanges();
            return this;
        }

        public override void Delete()
        {
            var article = context.Articles.SingleOrDefault(x => x.Id == Current.Id);
            context.Articles.Remove(article);
            context.SaveChanges();
        }

        protected Article Current
        {
            get { return this as Article; }
        }
    }
}
