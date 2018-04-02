using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.SubCategory
{
    public class SubCategoryGridViewModel : Helpers.Grid.IGridViewModel<SubCategoryGridRow>
    {
        public SubCategoryGridViewModel(int raceCategoryId)
        {
            this.raceCategoryId = raceCategoryId;
        }

        private int raceCategoryId;

        public string Id => "SubCategoryGrid_" + raceCategoryId;

        public string Name => "Podkategorie závodu";

        public string Url => "/Race/SubCategoryGridData?RaceCategoryId=" + raceCategoryId;

        public string addUrl => "/Race/SubCategoryEdit?RaceCategoryId=" + raceCategoryId;
    }
}