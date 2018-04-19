using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.RaceRegistration
{
    public class RaceCategoryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RaceSubCategoryResult> SubCategoriesResults { get; set; }

        public RaceCategoryResult(Data.Models.RaceCategory raceCategory)
        {
            /*
            var orderedRunners = raceCategory.RaceRounds.SelectMany(x => x.RaceRoundUsers)
                .GroupBy(x => x.RaceCategoryUserId).Select(x => new { userId = x.Key, time = x.Max(y => y.Time) })
                .OrderBy(x => x.time).Select((x, index) => new { userId = x.userId, time = x.time, order = index });


            
            var orderedSubCategoryRunners = raceCategory.RaceSubCategories.ToDictionary(dic => dic.Id,
                dic => dic.RaceCategoryUsers.SelectMany(x=>x.RaceRoundUsers)
                .GroupBy(x => x.RaceCategoryUserId).Select(x => new { userId = x.Key, time = x.Max(y => y.Time) })
                .OrderBy(x => x.time).Select((x, index) => new { userId = x.userId, time = x.time, order = index }));
                */

            Id = raceCategory.Id;
            Name = raceCategory.Name;
            SubCategoriesResults = raceCategory.RaceSubCategories.Select(x => new RaceSubCategoryResult
            {
                Id = x.Id,
                Name = x.Name,
                Rounds = x.RaceCategory.RaceRounds.Select(y=>y.Name).ToList(),
                Runners = x.RaceCategoryUsers.Where(y=>y.RunnerNumber.HasValue && y.RaceRoundUsers.Count > 0)
                .Select(y => new RaceRunnerRoundResult()
                {
                    FirstName = y.ApplicationUser.FirstName,
                    LastName = y.ApplicationUser.LastName,
                    Times = y.RaceRoundUsers.Where(z => z.RaceCategoryUserId == y.Id).Select(z => z.Time).ToList(),
                    RunnerNumber = y.RunnerNumber,
                    CategoryOrder = /*orderedRunners.First(ou => ou.userId == y.Id).order + 1*/ y.OrderInCategory,
                    SubCategoryOrder = /*orderedSubCategoryRunners.First(ou => ou.Key == x.Id).Value.First(ou => ou.userId == y.Id).order + 1*/ y.OrderInSubCategory
                }).ToList()
            }).ToList();
        }
    }
}