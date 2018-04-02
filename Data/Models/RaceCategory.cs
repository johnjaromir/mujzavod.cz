using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Data.Models
{
    public class RaceCategory:BaseEntity
    {
        public RaceCategory()
        {
            RaceSubCategories = new HashSet<RaceSubCategory>();
            RaceRounds = new HashSet<RaceRound>();
            RaceCategoryUsers = new HashSet<RaceCategoryUser>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        
        
        public DateTime Start { get; set; }

        public int RaceId { get; set; }
        public Race Race { get; set; }

        public double RegistrationPrice { get; set; }
        
        
        public virtual ICollection<RaceRound> RaceRounds { get; set; }

        public ICollection<RaceCategoryUser> RaceCategoryUsers { get; set; }
        public ICollection<RaceSubCategory> RaceSubCategories { get; set; }
    }
}
