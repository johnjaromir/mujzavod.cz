using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.RaceRegistration
{
    public class RaceSubCategoryResult
    {
        public string Name { get; set; }
        public List<RaceRunnerRoundResult> Runners {get;set;}
    }
}