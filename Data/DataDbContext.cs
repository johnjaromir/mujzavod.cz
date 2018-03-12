using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Data
{
    public class DataDbContext: IdentityDbContext<Identity.ApplicationUser>
    {
        public DataDbContext():base("PgSqlConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataDbContext, Migrations.Configuration>("PgSqlConnection"));
        }

        public static DataDbContext Create()
        {
            return new DataDbContext();
        }

        public DbSet<Models.Organizer> Organizers { get; set; }
        public DbSet<Models.Race> Races { get; set; }
        public DbSet<Models.RaceCategory> RaceCategories { get; set; }
        public DbSet<Models.RaceRound> RaceRounds { get; set; }
        public DbSet<Models.RaceRoundUser> RaceRoundUsers { get; set; }
        public DbSet<Models.RaceSubCategory> RaceSubCategories { get; set; }
        public DbSet<Models.RaceCategoryUser> RaceCategoryUsers { get; set; }


        // ciselniky
        public DbSet<Models.Enums.EGender> EGenders { get; set; }
    }
}
