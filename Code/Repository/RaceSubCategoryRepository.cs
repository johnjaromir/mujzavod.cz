using MujZavod.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MujZavod.Code.Repository
{
    public class RaceSubCategoryRepository : BaseRepository<RaceSubCategory>
    {
        protected override string dbSetContextName => "RaceSubCategories";


        public override IQueryable<RaceSubCategory> GetAll()
        {
            return base.GetAll().Include(x => x.AllowedGenders).Include(x => x.RaceCategory)
                .Include(x => x.RaceCategoryUsers.Select(y => y.ApplicationUser));
        }

        public IQueryable<RaceSubCategory> GetSubCategoryForUser(int genderId, DateTime birthDate, int raceCategoryId)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;

            return base.GetAll().Where(x=>
                x.RaceCategoryId == raceCategoryId &&
                x.AllowedGenders.Any(z => z.Id == genderId)
                    && (!x.AgeFrom.HasValue || x.AgeFrom.Value <= age)
                    && (!x.AgeTo.HasValue || x.AgeTo.Value >= age))
                    ;
        }


        public override void Remove(RaceSubCategory entity, bool saveChanges)
        {
            // smazeme navíc všechny závodníky co nejsou registrovaní
            var auRepo = new ApplicationUserRepository();
            var raceCategoryUsersRepo = new RaceCategoryUsersRepository();
            //entity.RaceCategoryUsers.Where(x => x.RaceSubCategory.RaceCategoryUsers.Any(y => y.ApplicationUser.Roles.Count() > 0))
            entity.RaceCategoryUsers.ToList().ForEach(x =>
            {
                raceCategoryUsersRepo.Remove(x, false);
            });
            base.Remove(entity, saveChanges);
        }
    }
}
