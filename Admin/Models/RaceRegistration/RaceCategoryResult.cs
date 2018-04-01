using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.RaceRegistration
{
    public class RaceCategoryResult
    {
        public string Name { get; set; }
        public List<RaceSubCategoryResult> SubCategoriesResults { get; set; }

        public RaceCategoryResult(Data.Models.RaceCategory raceCategory)
        {

            var orderedRunners = raceCategory.RaceRounds.SelectMany(x => x.RaceRoundUsers)
                .GroupBy(x => x.RaceCategoryUserId).Select(x => new { userId = x.Key, time = x.Max(y => y.Time) })
                .OrderBy(x => x.time).Select((x, index) => new { userId = x.userId, time = x.time, order = index });


            
            var orderedSubCategoryRunners = raceCategory.RaceSubCategories.ToDictionary(dic => dic.Id,
                dic => dic.RaceCategoryUsers.SelectMany(x=>x.RaceRoundUsers)
                .GroupBy(x => x.RaceCategoryUserId).Select(x => new { userId = x.Key, time = x.Max(y => y.Time) })
                .OrderBy(x => x.time).Select((x, index) => new { userId = x.userId, time = x.time, order = index }));

            
            Name = raceCategory.Name;
            SubCategoriesResults = raceCategory.RaceSubCategories.Select(x => new RaceSubCategoryResult
            {
                Name = x.Name,
                Runners = x.RaceCategoryUsers.Select(y => new RaceRunnerRoundResult()
                {
                    FirstName = y.ApplicationUser.FirstName,
                    LastName = y.ApplicationUser.LastName,
                    Times = y.RaceRoundUsers.Where(z => z.RaceCategoryUserId == x.Id).Select(z => z.Time).ToList(),
                    RunnerNumber = y.RunnerNumber,
                    CategoryOrder = orderedRunners.First(ou => ou.userId == y.Id).order,
                    SubCategoryOrder = orderedSubCategoryRunners.First(ou => ou.Key == x.Id).Value.First(ou => ou.userId == y.Id).order
                }).ToList()
            }).ToList();
        }
    }
}