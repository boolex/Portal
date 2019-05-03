namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPictureAndTags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.PictureTag",
                c => new
                    {
                        PictureRefId = c.String(nullable: false, maxLength: 128),
                        TagRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PictureRefId, t.TagRefId })
                .ForeignKey("dbo.Pictures", t => t.PictureRefId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagRefId, cascadeDelete: true)
                .Index(t => t.PictureRefId)
                .Index(t => t.TagRefId);
            
            CreateTable(
                "dbo.ArticlePicture",
                c => new
                    {
                        ArticleRefId = c.Int(nullable: false),
                        PictureRefId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ArticleRefId, t.PictureRefId })
                .ForeignKey("dbo.Articles", t => t.ArticleRefId, cascadeDelete: true)
                .ForeignKey("dbo.Pictures", t => t.PictureRefId, cascadeDelete: true)
                .Index(t => t.ArticleRefId)
                .Index(t => t.PictureRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticlePicture", "PictureRefId", "dbo.Pictures");
            DropForeignKey("dbo.ArticlePicture", "ArticleRefId", "dbo.Articles");
            DropForeignKey("dbo.PictureTag", "TagRefId", "dbo.Tags");
            DropForeignKey("dbo.PictureTag", "PictureRefId", "dbo.Pictures");
            DropIndex("dbo.ArticlePicture", new[] { "PictureRefId" });
            DropIndex("dbo.ArticlePicture", new[] { "ArticleRefId" });
            DropIndex("dbo.PictureTag", new[] { "TagRefId" });
            DropIndex("dbo.PictureTag", new[] { "PictureRefId" });
            DropTable("dbo.ArticlePicture");
            DropTable("dbo.PictureTag");
            DropTable("dbo.Pictures");
        }
    }
}
