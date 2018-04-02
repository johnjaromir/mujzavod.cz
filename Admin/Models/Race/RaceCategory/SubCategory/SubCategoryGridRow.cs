using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.SubCategory
{
    public class SubCategoryGridRow : Helpers.Grid.IGridRow
    {
        protected readonly Data.Models.RaceSubCategory raceSubCategory;
        public SubCategoryGridRow(Data.Models.RaceSubCategory raceSubCategory)
        {
            this.raceSubCategory = raceSubCategory;
        }

        public string Id => raceSubCategory.Id.ToString();

        [DisplayName("Název")]
        public string Name => raceSubCategory.Name;

        [DisplayName("Pro pohlaví")]
        public string ForGenders => string.Join(", ", raceSubCategory.AllowedGenders.Select(x => x.Name));

        [DisplayName("Věk od")]
        public string AgeFrom => raceSubCategory.AgeFrom.ToString();

        [DisplayName("Věk do")]
        public string AgeTo => raceSubCategory.AgeTo.ToString();

        public string Actions
        {
            get
            {
                string ret = "";

                ret += new Helpers.MzButton()
                {
                    innerHtml = "Upravit",
                    cssClass = "pull-right",
                    mzButtonType = Helpers.MzButton.MzButtonType.EDIT,
                    js = "new MujZavod.Modal().loadFromUrl('/Race/SubCategoryEdit?id=" + Id + "&raceCategoryId="+raceSubCategory.RaceCategoryId+"', function (modal) { MujZavod.Grids['SubCategoryGrid_" + raceSubCategory.RaceCategoryId+"'].refresh(); modal.close(); });"
                };

                return ret;
            }
        }
    }
}