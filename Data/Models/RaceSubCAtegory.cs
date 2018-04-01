using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Data.Models
{
    public class RaceSubCategory:BaseEntity
    {
        public RaceSubCategory()
        {
            RaceCategoryUsers = new HashSet<RaceCategoryUser>();
            AllowedGenders = new HashSet<Enums.EGender>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }

        public ICollection<Enums.EGender> AllowedGenders { get; set; }


        public int RaceCategoryId { get; set; }
        public RaceCategory RaceCategory { get; set; }

        public ICollection<RaceCategoryUser> RaceCategoryUsers { get; set; }
    }
}
