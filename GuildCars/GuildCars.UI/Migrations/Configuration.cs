namespace GuildCars.UI.Migrations
{
    using GuildCars.UI.Models.Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildCars.UI.Models.Identity.GuildCarsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildCars.UI.Models.Identity.GuildCarsDbContext context)
        {
            // Load the user and role managers with our custom models
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));
 
            // have we loaded roles already?
            if (roleMgr.RoleExists("admin"))
                return;

            // create the admin role
            roleMgr.Create(new AppRole() { Name = "admin" });
            roleMgr.Create(new AppRole() { Name = "sales" });
            roleMgr.Create(new AppRole() { Name = "disabled" });

            // create the default user
            var user = new AppUser()
            {
                UserName = "JAdmin",
                FirstName = "Joe",
                LastName = "Administrator",
                Email = "JoeA@GuildCars.com"
            };

            // create the user with the manager class
            userMgr.Create(user, "Testing123");
            
            // add the user to the admin role
            userMgr.AddToRole(user.Id, "admin");

            var user2 = new AppUser()
            {
                UserName = "JSalesGuy",
                FirstName = "Jack",
                LastName = "SalesGuy",
                Email = "JackS@GuildCars.com"
            };
            // create the user with the manager class
            userMgr.Create(user2, "Testing123");

            // add the user to the admin role
            userMgr.AddToRole(user2.Id, "sales");

            var user3 = new AppUser()
            {
                UserName = "BRyan",
                FirstName = "Bob",
                LastName = "Ryan",
                Email = "BobR@GuildCars.com"
            };
            // create the user with the manager class
            userMgr.Create(user3, "Testing123");

            // add the user to the admin role
            userMgr.AddToRole(user3.Id, "sales");

            var user4 = new AppUser()
            {
                UserName = "BUser",
                FirstName = "Bad",
                LastName = "User",
                Email = "BUser@GuildCars.com"
            };
            // create the user with the manager class
            userMgr.Create(user4, "Testing123");

            // add the user to the admin role
            userMgr.AddToRole(user4.Id, "disabled");

        }
    }
}
