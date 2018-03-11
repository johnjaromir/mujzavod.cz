using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory
{
    public class RaceCategoriesViewModel
    {
        public int RaceId { get; set; }
        public List<RaceCategoryViewModel> RaceCategories {get;set;}
    }
}