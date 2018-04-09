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
using System.Web;
using System.Collections;

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
            return Instance;
        }

        public static DataDbContext Instance
        {
            get
            {
                if (HttpContext.Current == null)
                    return new DataDbContext();

                DataDbContext dt = null;
                IDictionary items = HttpContext.Current.Items;
                if (!items.Contains("DataDbContext"))
                {
                    items["DataDbContext"] = new DataDbContext();
                }
                dt = items["DataDbContext"] as DataDbContext;
                return dt;
            }
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
