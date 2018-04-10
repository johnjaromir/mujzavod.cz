using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.SubCategory
{
    public class SubCategoryGridViewModel : Helpers.Grid.IGridViewModel<SubCategoryGridRow>
    {
        public SubCategoryGridViewModel(int raceCategoryId, bool canEdit)
        {
            this.raceCategoryId = raceCategoryId;
            this.canEdit = canEdit;
        }

        private int raceCategoryId;
        bool canEdit;

        public string Id => "SubCategoryGrid_" + raceCategoryId;

        public string Name => "Podkategorie závodu";

        public string Url => "/Race/SubCategoryGridData?RaceCategoryId=" + raceCategoryId;

        public string addUrl => canEdit ? ("/Race/SubCategoryEdit?RaceCategoryId=" + raceCategoryId) : string.Empty;
    }
}