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
            var query = base.GetAll();

            var actUser = new ApplicationUserRepository().GetActAu();
            query = query.Where(x => x.Race.OrganizerId == actUser.OrganizerId);

            return query;
        }
        

        public IQueryable<RaceCategory> GetCategoryForUser(string raceKey, int genderId, DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;

            return base.GetAll().Where(x => x.Race.RaceKey == raceKey
            && (/*x.RaceSubCategories.Count == 0
                || */(x.RaceSubCategories.Any(y => y.AllowedGenders.Any(z => z.Id == genderId)
                    && (!y.AgeFrom.HasValue || y.AgeFrom.Value <= age)
                    && (!y.AgeTo.HasValue || y.AgeTo.Value >= age))
                    )));
        }
    }
}
