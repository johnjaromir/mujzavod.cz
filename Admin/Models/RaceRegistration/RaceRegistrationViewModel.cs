using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.RaceRegistration
{
    public class RaceRegistrationViewModel
    {
        public int RaceId { get; set; }
        public string Name { get; set; }
        public DateTime? PublishDate { get; set; }


        public RaceRegistrationViewModel(Data.Models.Race race)
        {
            if (race != null)
            {
                RaceId = race.Id;
                Name = race.Name;
                PublishDate = race.PublishDate;
            }
        }
    }
}