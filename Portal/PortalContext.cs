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
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ArticlePage> ArticlePages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Article>()
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Comment>()
            .HasRequired<Article>(s => s.Article)
            .WithMany(g => g.Comments)
            .HasForeignKey<int>(s => s.ArticleId);

            modelBuilder.Entity<ArticlePage>()
               .HasKey(x => x.Id)
               .Property(x => x.Id)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<ArticlePage>().HasRequired(x => x.Article);
        }
    }
}
