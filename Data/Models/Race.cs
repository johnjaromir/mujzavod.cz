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
        public virtual Organizer Organizer { get; set; }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime SignToDate { get; set; }
        public string Description { get; set; }

        public string RaceKey { get; set; }
        public DateTime? PublishDate { get; set; }

        public DateTime? EndDate { get; set; }

        
        public virtual ICollection<RaceCategory> RaceCategories { get; set; }
    }
}
