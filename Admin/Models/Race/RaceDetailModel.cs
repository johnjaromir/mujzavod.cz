using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race
{
    public class RaceDetailModel
    {
        public RaceViewModel RaceViewModel { get; set; }
        public RaceCategory.RaceCategoriesViewModel RaceCategoriesViewModel { get; set; }

        public RaceDetailModel(Data.Models.Race race)
        {
            if (race != null)
            {
                RaceViewModel = new RaceViewModel(race);
                RaceCategoriesViewModel = new RaceCategory.RaceCategoriesViewModel()
                {
                    RaceId = race.Id,
                    RaceCategories = race.RaceCategories.Select(x => new RaceCategory.RaceCategoryViewModel(x, true)).ToList()
                };
            }
        }
    }
}