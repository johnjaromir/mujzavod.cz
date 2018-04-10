using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.Round
{
    public class RoundGridViewModel : Helpers.Grid.IGridViewModel<RoundGridRow>
    {
        public RoundGridViewModel(int raceCategoryId, bool canEdit)
        {
            this.raceCategoryId = raceCategoryId;
            this.canEdit = canEdit;
        }

        private int raceCategoryId;
        private bool canEdit;

        public string Id => "RoundGrid_"+raceCategoryId;

        public string Name => "Měřené úseky";

        public string Url => "/Race/RoundGridData/" + raceCategoryId;

        public string addUrl => canEdit ? ("/Race/CategoryRoundEdit?RaceCategoryId=" + raceCategoryId) : string.Empty;
    }
}