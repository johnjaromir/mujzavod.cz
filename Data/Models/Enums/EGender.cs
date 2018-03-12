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
        }
        public ICollection<RaceSubCategory> RaceSubCategories { get; set; }
    }
}
