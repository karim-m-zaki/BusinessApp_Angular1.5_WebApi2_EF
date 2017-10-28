namespace BusinessApp_AsgaTech.WebAPI.Migrations
{
    using BusinessApp_AsgaTech.Models.Models;
    using System.Data.Entity.Migrations;
    using System.Web.Helpers;

    internal sealed class Configuration : DbMigrationsConfiguration<AsgaTechContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AsgaTechContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.

            context.Users.AddOrUpdate(
               x => x.Id,
               new User { Id = 1, Email = "karim@gmail.com", Password = Crypto.HashPassword("1234"), UserName = "Kemo" }
               );

            context.Roles.AddOrUpdate(
                z => z.Id,
                new Role { Id = 1, RoleName = "Admin", Selected = false },
                new Role { Id = 2, RoleName = "Premium User", Selected = false },
                new Role { Id = 3, RoleName = "User", Selected = false }
                );
        }
    }
}