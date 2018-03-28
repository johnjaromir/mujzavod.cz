using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Race.RaceCategory.Round
{
    public class RoundViewModel
    {
        public int? Id { get; set; }
        public int RaceCategoryId { get; set; }
        [DisplayName("Název")]
        public string Name { get; set; }
        [DisplayName("Vzdálenost")]
        
        
        public double Distance { get; set; }

        public RoundViewModel()
        {

        }

        public RoundViewModel(Data.Models.RaceRound raceRound)
        {
            if (raceRound!= null)
            {
                Id = raceRound.Id;
                RaceCategoryId = raceRound.RaceCategoryId;
                Name = raceRound.Name;
                Distance = raceRound.Distance;
            }
        }
    }
}