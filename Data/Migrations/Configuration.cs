namespace MujZavod.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using MujZavod.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<DataDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataDbContext context)
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

            InitializeIdentity(context);
            InitializeDefaults(context);
        }

        /// <summary>
        /// Inicializace defaultnich hodnot pro nase entity
        /// </summary>
        /// <param name="context"></param>
        private void InitializeDefaults(DataDbContext context)
        {
            context.EGenders.AddOrUpdate(new Models.Enums.EGender() { Id = 1, Name = "Muž" });
            context.EGenders.AddOrUpdate(new Models.Enums.EGender() { Id = 2, Name = "Žena" });
            context.EGenders.AddOrUpdate(new Models.Enums.EGender() { Id = 3, Name = "Gender neutrality shit" });
            context.EGenders.AddOrUpdate(new Models.Enums.EGender() { Id = 4, Name = "Apache helicopter" });


            var organizer = new Models.Organizer()
            {
                Id = 1,
                Name = "Pořadatel 1",
            };

            context.Organizers.AddOrUpdate(organizer);


            var user = CreateUserIfNotExists(context, "poradatel", "johnjaromir@gmail.com", "Jaromír", "John",
                "test123", new[] { "Organizer" }, new DateTime(1991,04,26), 4, organizer.Id);

            

            
        }

        

        /// <summary>
        /// Inicializace roli a defaultnich uzivatelu
        /// </summary>
        /// <param name="context"></param>
        private void InitializeIdentity(DataDbContext context)
        {
            
            //vytvorime role
            
            CreateRoleIfNotExists(context, "Organizer", "Pořadatel");
            CreateRoleIfNotExists(context, "User", "Uživatel");

            
            
            
        }


        private void CreateRoleIfNotExists(DataDbContext context,string name, string description)
        {
            var roleManager = new MujZavod.Data.Identity.ApplicationRoleManager(
                new RoleStore<Identity.ApplicationRole>(context));

            var role = roleManager.FindByName(name);
            if (role == null)
            {
                role = new MujZavod.Data.Identity.ApplicationRole(name, description);
                var roleresult = roleManager.Create(role);
            }
        }

        
        private Identity.ApplicationUser CreateUserIfNotExists(DataDbContext context, string username, string email,
            string firstName,string lastName, string password, string[] roles, DateTime birthDate, int genderId, int organizerId)
        {
            var userManager = new MujZavod.Data.Identity.ApplicationUserManager(
                new UserStore<MujZavod.Data.Identity.ApplicationUser>(context));

            var user = userManager.FindByName(username);
            if (user == null)
            {
                user = new MujZavod.Data.Identity.ApplicationUser
                {
                    UserName = username,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = birthDate,
                    EGenderId = genderId,
                    OrganizerId = organizerId
                };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }


            var rolesForUser = userManager.GetRoles(user.Id);

            foreach (string role in roles)
            {
                if (!rolesForUser.Contains(role))
                {
                    var result = userManager.AddToRole(user.Id, role);
                }
            }

            return user;

        }
       
        

    }
}
