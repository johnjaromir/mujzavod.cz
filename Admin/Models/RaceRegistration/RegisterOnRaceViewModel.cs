using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MujZavod.Admin.Models.RaceRegistration
{
    public class RegisterOnRaceViewModel
    {
        public int Id { get; set; }
        public string RaceName { get; set; }

        // prihlaseni
        [DisplayName("Email")]
        public string EmailLogin { get; set; }
        [DisplayName("Heslo")]
        public string PasswordLogin { get; set; }

        public int RegistrationTypeId { get; set; }



        // registrace
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        

        [Required(ErrorMessage = "Datum narození je povinné")]
        [DisplayName("Datum narození")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Pohlaví je povinné")]
        [DisplayName("Pohlaví")]
        public int EGenderId { get; set; }

        [Required(ErrorMessage = "Jméno je povinné")]
        [DisplayName("Jméno")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Příjmení je povinné")]
        [DisplayName("Příjmení")]
        public string SurName { get; set; }

        [DisplayName("Přejete si vytvořit účet?")]
        public bool CreateAccount { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "{0} musí obsahovat alespoň {2} znaků.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrzení hesla")]
        [Compare("Password", ErrorMessage = "Heslo se neshoduje s potvrzením hesla.")]
        public string ConfirmPassword { get; set; }




        //************************************************************************************


        // vyber kategorie a subkategorie
        [DisplayName("Kategorie závodu")]
        public int RaceCategoryId { get; set; }
        [DisplayName("Podkategorie závodu")]
        public int RaceSubCategoryId { get; set; }

        public RegisterOnRaceViewModel()
        {

        }

        public RegisterOnRaceViewModel(Data.Models.Race race)
        {
            if (race != null)
            {
                Id = race.Id;
                RaceName = race.Name;
            }
        }
    }
}