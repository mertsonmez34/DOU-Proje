using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using E_Commerce.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace E_Commerce.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            // Rolleri
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() {Name = "admin", Description = "admin role"};
                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "user role" }; ;
                manager.Create(role);
            }

            if (!context.Users.Any(i => i.Name == "bahadiriren"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "bahadir", Surname = "iren", UserName = "bahadiriren", Email = "bahadiriren@gmail.com" };

                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }

            if (!context.Users.Any(i => i.Name == "mertsonmez"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "mert", Surname = "sonmez", UserName = "mertsonmez", Email = "mertsonmez@gmail.com" };

                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "admin");
            }

            if (!context.Users.Any(i => i.Name == "mucahidakca"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "mucahid", Surname = "akca", UserName = "mucahidakca", Email = "mucahidakca@gmail.com" };

                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "admin");
            }

            base.Seed(context);
        }
    }
}