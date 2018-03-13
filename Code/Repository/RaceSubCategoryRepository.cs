using MujZavod.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Code.Repository
{
    public class RaceSubCategoryRepository : BaseRepository<RaceSubCategory>
    {
        protected override string dbSetContextName => "RaceSubCategories";
    }
}
