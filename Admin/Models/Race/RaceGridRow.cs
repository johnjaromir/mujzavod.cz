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
                double? min = race.RaceCategories.Where(x => x.RaceRounds.Count > 0).Min(x => x.RaceRounds?.Max(y => (double?)y.Distance));
                double? max = race.RaceCategories.Where(x => x.RaceRounds.Count > 0).Max(a => a.RaceRounds?.Max(b => (double?)b.Distance));
                return min == max ? min.ToString() : (min + " - " + max);
            }
        }

        [DisplayName("Stav")]
        public string State
        {
            get
            {
                if (!race.PublishDate.HasValue)
                    return "Rozpracováno";
                else if (race.Date < DateTime.Now)
                    return "Publikováno";
                else
                    return "Proběhlý";
            }
        }

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