namespace AppSK.DAL.Migrations
{
    using AppSK.DAL.Context;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            var adminRole = new IdentityRole { Name = "Admin" };
            var managerRole = new IdentityRole { Name = "Manager" };
            var expertRole = new IdentityRole { Name = "Expert" };

            context.Roles.Add(adminRole);
            context.Roles.Add(managerRole);
            context.Roles.Add(expertRole);

            base.Seed(context);
        }
    }
}
