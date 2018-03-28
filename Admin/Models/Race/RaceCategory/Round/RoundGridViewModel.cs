using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.Round
{
    public class RoundGridViewModel : Helpers.Grid.IGridViewModel<RoundGridRow>
    {
        public RoundGridViewModel(int raceCategoryId)
        {
            this.raceCategoryId = raceCategoryId;
        }

        private int raceCategoryId;

        public string Id => "RoundGrid_"+raceCategoryId;

        public string Name => "Kola závodu";

        public string Url => "/Race/RoundGridData/" + raceCategoryId;

        public string addUrl => "/Race/CategoryRoundEdit?RaceCategoryId=" + raceCategoryId;
    }
}