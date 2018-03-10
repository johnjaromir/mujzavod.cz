using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Data.Models
{
    public class Organizer:BaseEntity
    {
        public Organizer()
        {
            Organizers = new HashSet<Identity.ApplicationUser>();
            
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Identity.ApplicationUser> Organizers { get; set; }
       
    }
}
