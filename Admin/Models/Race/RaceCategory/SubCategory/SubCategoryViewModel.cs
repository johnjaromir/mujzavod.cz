using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MujZavod.Admin.Models.Race.RaceCategory.SubCategory
{
    public class SubCategoryViewModel
    {
        public int? Id { get; set; }
        public int RaceCategoryId { get; set; }

        [DisplayName("Název")]
        public string Name { get; set; }

        [DisplayName("Pro pohlaví")]
        public System.Web.Mvc.SelectList possibleGenders { get; set; }
        public IEnumerable<string> SelectedGenders { get; set; }

        [DisplayName("Věk od")]
        public int? AgeFrom { get; set; }
        [DisplayName("Věk do")]
        public int? AgeTo { get; set; }

        public string GendersText { get; set; }

        

        public SubCategoryViewModel()
        {
            possibleGenders = new SelectList(new DropDown.EGenderDropDownModel().items, "Value", "Text");
        }

        public SubCategoryViewModel(Data.Models.RaceSubCategory raceSubCategory)
        {
            if (raceSubCategory != null)
            {
                Id = raceSubCategory.Id;
                RaceCategoryId = raceSubCategory.RaceCategoryId;
                Name = raceSubCategory.Name;
                AgeFrom = raceSubCategory.AgeFrom;
                AgeTo = raceSubCategory.AgeTo;
                possibleGenders = new SelectList(new DropDown.EGenderDropDownModel().items, "Value", "Text");
                SelectedGenders = raceSubCategory.AllowedGenders.Select(x => x.Id.ToString()).ToList();

                GendersText = string.Join(",", raceSubCategory.AllowedGenders.Select(x => x.Name));

                
            }
        }
    }
}