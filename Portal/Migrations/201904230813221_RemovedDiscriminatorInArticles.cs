namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDiscriminatorInArticles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Articles");
        }
    }
}
