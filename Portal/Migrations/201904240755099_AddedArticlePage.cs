namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedArticlePage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticlePages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        UrlName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticlePages", "ArticleId", "dbo.Articles");
            DropIndex("dbo.ArticlePages", new[] { "ArticleId" });
            DropTable("dbo.ArticlePages");
        }
    }
}
