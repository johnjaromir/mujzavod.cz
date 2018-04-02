using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.RaceRunners
{
    public class RaceRunnersGridViewModel : Helpers.Grid.IGridViewModel<RaceRunnersGridRow>
    {
        protected readonly int raceCategoryId;
        public RaceRunnersGridViewModel(int raceCategoryId)
        {
            
            this.raceCategoryId = raceCategoryId;
        }

        public string Id => "RaceRunnersGrid_" + raceCategoryId;

        public string Name => "Seznam závodníků";

        public string Url => "/Race/RaceRunnersGridData?raceCategoryId=" + raceCategoryId;

        public string addUrl => $"/Race/SubCategoryUserEdit?RaceCategoryId={raceCategoryId}";
    }
}