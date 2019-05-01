namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleTag",
                c => new
                    {
                        ArticleRefId = c.Int(nullable: false),
                        TagRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleRefId, t.TagRefId })
                .ForeignKey("dbo.Articles", t => t.ArticleRefId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagRefId, cascadeDelete: true)
                .Index(t => t.ArticleRefId)
                .Index(t => t.TagRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleTag", "TagRefId", "dbo.Tags");
            DropForeignKey("dbo.ArticleTag", "ArticleRefId", "dbo.Articles");
            DropIndex("dbo.ArticleTag", new[] { "TagRefId" });
            DropIndex("dbo.ArticleTag", new[] { "ArticleRefId" });
            DropTable("dbo.ArticleTag");
            DropTable("dbo.Tags");
        }
    }
}
