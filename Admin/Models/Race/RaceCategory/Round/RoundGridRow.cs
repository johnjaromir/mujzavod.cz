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

                ret += "<span class='pull-right'>";


                if (!raceRound.RaceCategory.Race.PublishDate.HasValue)
                {
                    ret += new Helpers.MzButton()
                    {
                        cssClass = "btn-sm m-l-1",
                        innerHtml = "Upravit",
                        mzButtonType = Helpers.MzButton.MzButtonType.EDIT,
                        js = "new MujZavod.Modal().loadFromUrl('/Race/CategoryRoundEdit/" + Id + "?RaceCategoryId=" + raceRound.RaceCategoryId + "', function (modal) { modal.close(); MujZavod.Grids['RoundGrid_" + raceRound.RaceCategoryId + "'].refresh() });"
                    };

                    ret += new Helpers.MzButton()
                    {
                        innerHtml = "Smazat",
                        cssClass = "btn-sm m-l-1",
                        mzButtonType = Helpers.MzButton.MzButtonType.DELETE,
                        js = "MujZavod.Confirm('Opravdu si přejete smazat měřený úsek?', function() { MujZavod.DoAction('/Race/RemoveRaceRound?id=" + Id + "', function () { MujZavod.Grids['RoundGrid_" + raceRound.RaceCategoryId + "'].refresh(); }); } );"
                    };
                }

                ret += "</span>";

                return ret;
            }
        }
    }
}