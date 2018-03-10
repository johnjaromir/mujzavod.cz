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
            AllowedGenders = new HashSet<Enums.EGender>();
            Racers = new HashSet<Identity.ApplicationUser>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        public DateTime Start { get; set; }

        public int RaceId { get; set; }
        public Race Race { get; set; }

        public ICollection<Enums.EGender> AllowedGenders { get; set; }
        public ICollection<Identity.ApplicationUser> Racers { get; set; }
    }
}
