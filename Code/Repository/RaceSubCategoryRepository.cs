using MujZavod.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Code.Repository
{
    public class RaceSubCategoryRepository : BaseRepository<RaceSubCategory>
    {
        protected override string dbSetContextName => "RaceSubCategories";



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
    }
}
