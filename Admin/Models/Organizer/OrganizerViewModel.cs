using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.Organizer
{
    public class OrganizerViewModel
    {
        public int? Id { get; set; }
        [Required]
        [Display(Name = "Název pořadatele")]
        public string Name { get; set; }
        [Display(Name = "Popis pořadatele")]
        public string Description { get; set; }

        public OrganizerViewModel()
        {

        }
        public OrganizerViewModel(Data.Models.Organizer organizer)
        {
            if (organizer != null)
            {
                Id = organizer.Id;
                Name = organizer.Name;
                Description = organizer.Description;
            }
        }
    }
}