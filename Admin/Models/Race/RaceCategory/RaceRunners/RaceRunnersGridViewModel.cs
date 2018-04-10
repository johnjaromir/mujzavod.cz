using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.RaceRunners
{
    public class RaceRunnersGridViewModel : Helpers.Grid.IGridViewModel<RaceRunnersGridRow>
    {
        protected readonly int raceCategoryId;
        bool canEdit;
        public RaceRunnersGridViewModel(int raceCategoryId, bool canEdit)
        {
            
            this.raceCategoryId = raceCategoryId;
            this.canEdit = canEdit;
        }

        public string Id => "RaceRunnersGrid_" + raceCategoryId;

        public string Name => "Seznam závodníků";

        public string Url => "/Race/RaceRunnersGridData?raceCategoryId=" + raceCategoryId;

        public string addUrl => canEdit ? $"/Race/SubCategoryUserEdit?RaceCategoryId={raceCategoryId}" : string.Empty;
    }
}