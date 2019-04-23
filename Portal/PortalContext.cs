using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Portal.Articles;

namespace Portal
{
    public class PortalContext : DbContext
    {
        public PortalContext()
            : base("DbConnection")
        { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Article>()
                .HasKey(x=>x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Page>().HasRequired(x => x.Article);
            modelBuilder.Entity<Page>().HasKey(x => x.Article);

            modelBuilder.Entity<Comment>().HasRequired(x => x.Article);
            modelBuilder.Entity<Comment>().HasRequired(x => x.Article).WithMany().HasForeignKey(x => x.ArticleId);

            modelBuilder.Entity<Social>().HasRequired(x => x.Article);
            modelBuilder.Entity<Social>().HasRequired(x => x.Article).WithMany().HasForeignKey(x => x.ArticleId);

            modelBuilder.Entity<Stats>().HasRequired(x => x.Article);
            modelBuilder.Entity<Stats>().HasRequired(x => x.Article).WithMany().HasForeignKey(x => x.ArticleId);
        }
    }
}
