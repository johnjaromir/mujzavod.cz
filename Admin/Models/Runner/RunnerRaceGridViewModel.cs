using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Runner
{
    public class RunnerRaceGridViewModel : Helpers.Grid.IGridViewModel<RunnerRaceGridRow>
    {


        public string Id => "RunnerRacesGrid";

        public string Name => "Seznam mých závodů";

        public string Url => "/Runner/RunnerRacesGridData";

        public string addUrl => string.Empty;
    }
}