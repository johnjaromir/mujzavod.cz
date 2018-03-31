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


        public RaceRunnerEditViewModel()
        {

        }

        public RaceRunnerEditViewModel(Data.Models.RaceCategoryUser raceCategoryUser)
            :base(raceCategoryUser.ApplicationUser)
        {
            RunnerNumber = raceCategoryUser.RunnerNumber;
            Id = raceCategoryUser.Id.ToString();
        }
    }
}