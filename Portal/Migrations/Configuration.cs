using System.Data.Entity.Migrations;

namespace Portal.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<Portal.PortalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Portal.PortalContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
