namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDiscriminatorInArticles2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Discriminator");
        }
    }
}
