using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MujZavod.Data.Identity
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        
        public int EGenderId { get; set; }
        public Models.Enums.EGender EGender { get; set; }

        public string ReadableName => $"{FirstName} {LastName}";

        public int? OrganizerId { get; set; }
        public Models.Organizer Organizer { get; set; }
        //public ICollection<Data.Models.Organizer> UserForOrganizer { get; set; }

        public ICollection<Models.RaceCategory> RaceCategories { get; set; }
        public ICollection<Models.RaceRoundUser> RaceRounds { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name, string description) : base(name)
        {
            this.Description = description;
        }
        public virtual string Description { get; set; }
    }

    /*public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("PgSqlConnection", throwIfV1Schema: true)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }*/
}