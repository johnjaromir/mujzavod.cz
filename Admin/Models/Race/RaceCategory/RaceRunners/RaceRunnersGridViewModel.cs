using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.RaceRunners
{
    public class RaceRunnersGridViewModel : Helpers.Grid.IGridViewModel<RaceRunnersGridRow>
    {
        protected readonly int? raceSubCategoryId;
        protected readonly int raceCategoryId;
        public RaceRunnersGridViewModel(int raceCategoryId, int? raceSubCategoryId)
        {
            this.raceSubCategoryId = raceSubCategoryId;
            this.raceCategoryId = raceCategoryId;
        }

        public string Id => "RaceRunnersGrid_" + raceCategoryId + "_" + raceSubCategoryId;

        public string Name => "Seznam závodníků";

        public string Url => "/Race/RaceRunnersGridData?raceCategoryId=" + raceCategoryId + "&raceSubCategoryId=" + raceSubCategoryId;

        public string addUrl => $"/Race/SubCategoryUserEdit?RaceCategoryId={raceCategoryId}&RaceSubCategoryId={raceSubCategoryId}";
    }
}