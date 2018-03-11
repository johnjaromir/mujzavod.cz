using MujZavod.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Code.Repository
{
    public class RaceCategoryRepository : BaseRepository<RaceCategory>
    {
        protected override string dbSetContextName => "RaceCategories";

        
        public override IQueryable<RaceCategory> GetAll()
        {
            var query = base.GetAll().Include(x=>x.AllowedGenders);

            var actUser = new ApplicationUserRepository().GetActAu();
            query = query.Where(x => x.Race.OrganizerId == actUser.OrganizerId);

            return query;
        }
        
    }
}
