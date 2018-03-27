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

        public IEnumerable<RaceCategoryUser> getUsers(int categoryId, int? subCategoryId)
        {
            return GetAll(x => x.RaceCategoryId == categoryId && x.RaceSubCategoryId == subCategoryId)
                .Include(x=>x.ApplicationUser).Include(x=>x.ApplicationUser.EGender).AsEnumerable();
        }
            
    }
}
