using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MujZavod.Admin.Models.Race.RaceCategory
{
    public class RaceCategoryViewModel
    {
        public int? Id { get; set; }
        public int RaceId { get; set; }

        [DisplayName("Název")]
        public string Name { get; set; }
        [DisplayName("Popis")]
        [AllowHtml]
        public string Description { get; set; }

        [DisplayName("Start")]
        [Required]
        public DateTime? Start { get; set; }


        
        public Round.RoundGridViewModel RoundGridViewModel { get; set; }


        public RaceCategoryViewModel()
        {
            
        }

        public RaceCategoryViewModel(Data.Models.RaceCategory raceCategory)
        {
            if (raceCategory != null)
            {
                Id = raceCategory.Id;
                Name = raceCategory.Name;
                RaceId = raceCategory.RaceId;
                Description = raceCategory.Description;
                

                Start = raceCategory.Start;

                RoundGridViewModel = new Round.RoundGridViewModel(raceCategory.Id);
            }
        }
    }
}