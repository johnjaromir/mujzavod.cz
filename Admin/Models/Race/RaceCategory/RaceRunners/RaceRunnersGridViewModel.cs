using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.RaceRunners
{
    public class RaceRunnersGridViewModel : Helpers.Grid.IGridViewModel<RaceRunnersGridRow>
    {
        protected readonly int? raceSubCategoryId;
        public RaceRunnersGridViewModel(int? raceSubCategoryId)
        {
            this.raceSubCategoryId = raceSubCategoryId;
        }

        public string Id => "RaceRunnersGrid_" + raceSubCategoryId;

        public string Name => "Seznam závodníků";

        public string Url => "/Race/RaceRunners?raceSubCategoryId=" + raceSubCategoryId;
    }
}