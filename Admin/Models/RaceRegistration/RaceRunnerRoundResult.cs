using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.RaceRegistration
{
    public class RaceRunnerRoundResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<TimeSpan> Times { get; set; }
        public int? RunnerNumber { get; set; }
        public int? CategoryOrder { get; set; }
        public int? SubCategoryOrder { get; set; }
    }
}