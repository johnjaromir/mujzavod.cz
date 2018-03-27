using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.User.NotRegistered
{
    public class NotRegisteredViewModel
    {
        public string Id { get; set; }

        public int? RaceCategoryId { get; set; }
        public int? RaceSubCategoryId { get; set; }

        [Required]
        [DisplayName("Jméno")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Příjmení")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Pohlaví")]
        public int GenderId { get; set; }
        [Required]
        [DisplayName("Datum narození")]
        public DateTime? BirthDate { get; set; }

        public NotRegisteredViewModel()
        {

        }

        public NotRegisteredViewModel(Data.Identity.ApplicationUser applicationUser)
        {
            if (applicationUser != null)
            {
                this.Id = applicationUser.Id;
                FirstName = applicationUser.FirstName;
                LastName = applicationUser.LastName;
                BirthDate = applicationUser.BirthDate;
                GenderId = applicationUser.EGenderId;
            }
        }
    }
}