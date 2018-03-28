using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race
{
    public class RaceGridRow : Helpers.Grid.IGridRow
    {
        protected readonly Data.Models.Race race;
        public RaceGridRow(Data.Models.Race race)
        {
            this.race = race;
        }

        public RaceGridRow()
        {

        }

        public string Id => race.Id.ToString();


        [DisplayName("Název")]
        public string Name => race.Name;

        [DisplayName("Datum")]
        public string Date => race.Date.ToShortDateString();

        [DisplayName("Přihlášení do")]
        public string SignToDate => race.SignToDate.ToShortDateString();

        [DisplayName("Vzdálenost")]
        public string Distance
        {
            get
            {
                if (race.RaceCategories == null)
                    return string.Empty;
                return race.RaceCategories.Min(x => x.RaceRounds?.Min(y => (double?)y.Distance)) + " - " + race.RaceCategories.Max(a => a.RaceRounds?.Max(b => (double?)b.Distance));
            }
        }

        [DisplayName("Stav")]
        public string State => "Rozpracováno";

        [DisplayName("Počet závodníků")]
        public string RunnersCount => race.RaceCategories.Sum(x => x.RaceCategoryUsers.Sum(y => y.Id)).ToString();

        public string Actions
        {
            get
            {
                string ret = string.Empty;

                ret += new Helpers.MzButton()
                {
                    innerHtml = "Detail",
                    cssClass = "pull-right",
                    mzButtonType = Helpers.MzButton.MzButtonType.DETAIL,
                    href = "/Race/Detail/" + Id
                };

                return ret;
            }
        }
    }
}