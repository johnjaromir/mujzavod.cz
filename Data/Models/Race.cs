using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Data.Models
{
    public class Race : BaseEntity
    {
        public Race()
        {
            
            RaceCategories = new HashSet<RaceCategory>();
        }

        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime SignToDate { get; set; }
        public string Description { get; set; }

        
        public ICollection<RaceCategory> RaceCategories { get; set; }
    }
}
