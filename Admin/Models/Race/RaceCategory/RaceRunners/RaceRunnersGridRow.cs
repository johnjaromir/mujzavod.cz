using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.RaceRunners
{
    public class RaceRunnersGridRow : Helpers.Grid.IGridRow
    {
        readonly MujZavod.Data.Models.RaceCategoryUser raceCategoryUser;

        public RaceRunnersGridRow(MujZavod.Data.Models.RaceCategoryUser raceCategoryUser)
        {
            this.raceCategoryUser = raceCategoryUser;
        }

        public string Id => raceCategoryUser.ApplicationUser.Id;
        public string FirstName => raceCategoryUser.ApplicationUser.FirstName;
        public string LastName => raceCategoryUser.ApplicationUser.LastName;

        public string Gender => raceCategoryUser.ApplicationUser.EGender.Name;

        public string Actions
        {
            get
            {
                string ret = "";

                ret += "<a class=\"pull-right btn btn-info\" onclick=\"new MujZavod.Modal().loadFromUrl('/Race/SubCategoryUserEdit?id=" + Id + "', function (modal) { MujZavod.Grids['RaceRunnersGrid_"+ raceCategoryUser.RaceCategoryId+ "_"+ raceCategoryUser .RaceSubCategoryId+ "'].refresh(); modal.close(); });\">Upravit</a>";

                return ret;
            }
        }
    }
}