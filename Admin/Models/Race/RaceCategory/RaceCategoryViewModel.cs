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
        [DisplayName("Věk od")]
        public int? AgeFrom { get; set; }
        [DisplayName("Věk do")]
        public int? AgeTo { get; set; }
        [DisplayName("Start závodu")]
        [Required]
        public DateTime? Start { get; set; }


        [DisplayName("Pro pohlaví")]
        public System.Web.Mvc.SelectList possibleGenders { get; set; }
        public IEnumerable<string> SelectedGenders { get; set; }


        public RaceCategoryViewModel()
        {
            possibleGenders = new SelectList(new DropDown.EGenderDropDownModel().items, "Value", "Text");
        }

        public RaceCategoryViewModel(Data.Models.RaceCategory raceCategory)
        {
            if (raceCategory != null)
            {
                Id = raceCategory.Id;
                Name = raceCategory.Name;
                RaceId = raceCategory.RaceId;
                Description = raceCategory.Description;
                AgeFrom = raceCategory.AgeFrom;
                AgeTo = raceCategory.AgeTo;

                Start = raceCategory.Start;
                possibleGenders = new SelectList(new DropDown.EGenderDropDownModel().items, "Value", "Text");
                SelectedGenders = raceCategory.AllowedGenders.Select(x => x.Id.ToString()).ToList();
            }
        }
    }
}