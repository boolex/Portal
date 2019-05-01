﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Portal.Articles;
using Portal.Tags;

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

            modelBuilder.Entity<Article>()
                   .HasMany<Tag>(s => s.Tags)
                   .WithMany(c => c.Articles)
                   .Map(cs =>
                   {
                       cs.MapLeftKey("ArticleRefId");
                       cs.MapRightKey("TagRefId");
                       cs.ToTable("ArticleTag");
                   });

            modelBuilder.Entity<ArticlePage>().HasRequired(x => x.Article);
        }
    }
}
