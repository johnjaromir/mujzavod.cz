﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MujZavod.Admin.Models.Race
{
    public class RaceViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Název")]
        public string Name { get; set; }
        [DisplayName("Datum")]
        public DateTime Date { get; set; }
        [DisplayName("Registrace do")]
        public DateTime SignToDate { get; set; }
        [DisplayName("Popis")]
        [AllowHtml]
        public string RaceDescription { get; set; }

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
            }
        }
    }
}