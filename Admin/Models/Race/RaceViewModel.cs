using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MujZavod.Admin.Models.Race
{
    public class RaceViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Název")]
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Datum")]
        public DateTime? Date { get; set; }
        [DisplayName("Registrace do")]
        [Required]
        public DateTime? SignToDate { get; set; }
        [DisplayName("Popis")]
        [AllowHtml]
        public string RaceDescription { get; set; }

        [DisplayName("Datum zveřejnění")]
        public DateTime? PublishDate { get; set; }

        public DateTime? EndDtae { get; set; }

        public string RaceKey { get; set; }

        public RaceViewModel()
        {

        }

        public RaceViewModel(Data.Models.Race race)
        {
            if (race != null)
            {
                Id = race.Id;
                Name = race.Name;
                Date = race.Date;
                SignToDate = race.SignToDate;
                RaceDescription = race.Description;
                PublishDate = race.PublishDate;
                RaceKey = race.RaceKey;
                EndDtae = race.EndDate;
            }
        }
    }
}