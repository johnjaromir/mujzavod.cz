using MujZavod.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Code.Repository
{
    public class RaceCategoryUsersRepository : BaseRepository<RaceCategoryUser>
    {
        protected override string dbSetContextName => "RaceCategoryUsers";

        /*
        public override IQueryable<RaceCategoryUser> GetAll()
        {
            return base.GetAll().Include(x => x.ApplicationUser.EGender);
        }
        */

        public IEnumerable<RaceCategoryUser> getUsers(int categoryId)
        {
            return GetAll(x => x.RaceCategoryId == categoryId)
                .Include(x=>x.ApplicationUser)
                .Include(x=>x.ApplicationUser.EGender)
                .Include(x=>x.ApplicationUser.Roles)
                .Include(x=>x.RaceSubCategory)
                .Include(x=>x.RaceCategory)
                .Include(x=>x.RaceCategory.Race)
                .Include(x=>x.RaceRoundUsers)
                .AsEnumerable();
        }
            

        public RaceCategoryUser getUserWithRounds(int userId)
        {
            return GetAll().
                Include(x => x.RaceCategory)
                .Include(x => x.RaceCategory.RaceRounds)
                .Include(x => x.RaceRoundUsers)
                .FirstOrDefault(x => x.Id == userId);
        }
    }
}
