using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Data.Models
{
    public class RaceCategoryUser:BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public Identity.ApplicationUser ApplicationUser { get; set; }

        public int RaceCategoryId { get; set; }
        public RaceCategory RaceCategory { get; set; }

        public int? RaceSubCategoryId { get; set; }
        public RaceSubCategory RaceSubCategory { get; set; }
    }
}
