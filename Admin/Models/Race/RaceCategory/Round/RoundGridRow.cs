using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.Round
{
    public class RoundGridRow : Helpers.Grid.IGridRow
    {
        protected readonly Data.Models.RaceRound raceRound;

        public RoundGridRow(Data.Models.RaceRound raceRound)
        {
            this.raceRound = raceRound;
        }

        
        public string Id => raceRound.Id.ToString();

        [DisplayName("Název")]
        public string Name => raceRound.Name;

        [DisplayName("Vzdálenost")]
        public string Distance => raceRound.Distance.ToString();


        public string Actions
        {
            get
            {
                string ret = string.Empty;

                ret += $"<a href='#' onclick=\"new MujZavod.Modal().loadFromUrl('/Race/CategoryRoundEdit/"+Id+"?RaceCategoryId="+raceRound.RaceCategoryId+"', function (modal) { location.reload(); });\" class='btn btn-default' >Upravit</a>";

                return ret;
            }
        }
    }
}