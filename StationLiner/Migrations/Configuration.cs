using StationLinerMVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StationLinerMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    
    internal sealed class Configuration : DbMigrationsConfiguration<StationLinerMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StationLinerMVC.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
//            var UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>());
//            var user = new ApplicationUser { UserName = "Admin", Email = "admin@ims.com" };
//            var result = UserManager.CreateAsync(user,"123456");
           context.Users.AddOrUpdate(
               u => u.Email, new ApplicationUser { UserName = "Alex", Email = "admin@ims.com", PasswordHash = "AOgdgABHGhWOQZofzf2uzk2MA/PG/FK2tZYZi9WYXbgZ8kA0ytx42VHfPdGyIEBbaw==" }
               );
//            context.Users.First()
        }
    }
}
