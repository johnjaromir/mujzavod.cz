using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Code.Repository
{
    public class EGenderRepository : BaseRepository<Data.Models.Enums.EGender>
    {
        
        

        protected override string dbSetContextName => "EGenders";
    }
}
