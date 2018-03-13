using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.RaceRunners
{
    public class RaceRunnersGridRow : Helpers.Grid.IGridRow
    {
        readonly MujZavod.Data.Identity.ApplicationUser applicationUser;

        public RaceRunnersGridRow(MujZavod.Data.Identity.ApplicationUser applicationUser)
        {
            this.applicationUser = applicationUser;
        }

        public string Id => applicationUser.Id;
        public string FirstName => applicationUser.FirstName;
        public string LastName => applicationUser.LastName;

        public string Gender => applicationUser.EGender.Name;

        public string Actions
        {
            get
            {
                string ret = "";

                ret += "<a class=\"pull-right btn btn-info\" onclick=\"new MujZavod.Modal().loadFromUrl('/Race/SubCategoryEdit?id=" + Id + "', function (modal) { location.reload(); });\">Upravit</a>";

                return ret;
            }
        }
    }
}