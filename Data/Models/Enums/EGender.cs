using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Data.Models.Enums
{
    public class EGender:BaseEnum
    {
        public EGender()
        {
            RaceSubCategories = new HashSet<RaceSubCategory>();
            ApplicationUsers = new HashSet<Identity.ApplicationUser>();
        }
        public ICollection<RaceSubCategory> RaceSubCategories { get; set; }
        public ICollection<Identity.ApplicationUser> ApplicationUsers { get; set; }
    }
}
