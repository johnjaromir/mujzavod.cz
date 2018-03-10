using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race
{
    public class RaceGridViewModel : Helpers.Grid.IGridViewModel<RaceGridRow>
    {
        

        public string Id => "GridRaces";

        public string Name => "Seznam závodů";

        public string Url => "/Race/GridData";
    }
}