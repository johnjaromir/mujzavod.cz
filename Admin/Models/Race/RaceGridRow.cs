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

        public string Actions
        {
            get
            {
                string ret = string.Empty; ;

                ret += $"<a href='/Race/Detail/{Id}' class='btn btn-default' >Detail</a>";

                return ret;
            }
        }
    }
}