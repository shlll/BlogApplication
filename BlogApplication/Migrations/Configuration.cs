namespace BlogApplication.Migrations
{
    using BlogApplication.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BlogApplication.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Roles.Any(r => r.Name == "Mike"))
            {
                roleManager.Create(new IdentityRole { Name = "Mike" });
            }
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Monderator" });
            }

            ApplicationUser adminUser = null;
            if (!context.Users.Any(p => p.UserName == "mike.shenhanlin@gmail.com"))
            {
                adminUser = new ApplicationUser();
                adminUser.UserName = "mike.shenhanlin@gmail.com";
                adminUser.Email = "mike.shenhanlin@gmail.com";
                adminUser.FirstName = "Mike";
                adminUser.LastName = "Shen";
                adminUser.DisplayName = "Mike Shen";

                userManager.Create(adminUser, "Password-1");
            }
            else
            {
                adminUser = context.Users.Where(p => p.UserName == "mike.shenhanlin@gmail.com").FirstOrDefault();
            }

            
            if (!userManager.IsInRole(adminUser.Id, "Mike"))
            {
                userManager.AddToRole(adminUser.Id, "Mike");
            }
        }
    }
}
