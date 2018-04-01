using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.RaceRegistration
{
    public class RaceRegistrationViewModel
    {
        public int RaceId { get; set; }
        [DisplayName("Název")]
        public string Name { get; set; }
        [DisplayName("Popis")]
        public string Description { get; set; }
        [DisplayName("Datum")]
        public DateTime Date { get; set; }
        [DisplayName("Registrace do")]
        public DateTime SignToDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string RaceKey { get; set; }


        public RaceRegistrationViewModel(Data.Models.Race race)
        {
            if (race != null)
            {
                RaceId = race.Id;
                Name = race.Name;
                Description = race.Description;
                Date = race.Date;
                SignToDate = race.SignToDate;
                PublishDate = race.PublishDate;
                EndDate = race.EndDate;
                RaceKey = race.RaceKey;
            }
        }
    }
}