namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDiscriminatorInArticles3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Articles", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
