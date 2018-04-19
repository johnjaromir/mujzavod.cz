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
    public class RaceRepository : BaseRepository<Race>
    {
        protected override string dbSetContextName => "Races";

        
        public override IQueryable<Race> GetAll()
        {
            var query = base.GetAll()
                .Include(x => x.RaceCategories)
                .Include(x => x.RaceCategories.Select(y => y.RaceSubCategories))
                .Include(x => x.RaceCategories.Select(y => y.RaceRounds))
                .Include(x => x.RaceCategories.Select(y => y.RaceCategoryUsers.Select(z => z.ApplicationUser)));

            var actUser = new ApplicationUserRepository().GetActAu();
            query = query.Where(x => x.OrganizerId == actUser.OrganizerId);

            return query;
        }
        
        public Race getRaceByKey(string raceKey)
        {
            return base.GetAll().Where(x => x.RaceKey == raceKey).FirstOrDefault();
        }

        public Race getRaceByKeyDetail(string raceKey)
        {
            return base.GetAll().Where(x => x.RaceKey == raceKey)
                .Include(x => x.RaceCategories)
                .Include(x => x.RaceCategories.Select(y => y.RaceSubCategories.Select(z => z.RaceCategoryUsers.Select(u => u.RaceRoundUsers))))
                .Include(x => x.RaceCategories.Select(y => y.RaceRounds.Select(z => z.RaceRoundUsers)))
                .FirstOrDefault();
        }


        public override void Remove(Race entity, bool saveChanges)
        {
            var raceCategoryRepo = new RaceCategoryRepository();
            entity.RaceCategories.ToList().ForEach(x => raceCategoryRepo.Remove(x, false));
            base.Remove(entity, saveChanges);
        }

        
    }
}
