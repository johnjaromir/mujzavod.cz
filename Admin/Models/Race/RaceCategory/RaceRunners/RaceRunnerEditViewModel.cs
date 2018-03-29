using MujZavod.Admin.Models.User.NotRegistered;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.RaceRunners
{
    public class RaceRunnerEditViewModel:NotRegisteredViewModel
    {
        [DisplayName("Číslo běžce")]
        public int? RunnerNumber { get; set; }
    }
}