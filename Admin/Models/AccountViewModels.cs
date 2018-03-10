using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MujZavod.Admin.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Uživatelské jméno")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Uživatelské jméno")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [Display(Name = "Pamatovat si mě?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Uživatelské jméno")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí obsahovat alespoň {2} znaků.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrzení hesla")]
        [Compare("Password", ErrorMessage = "Heslo se neshoduje s potvrzením hesla.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Datum narození je povinné")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Pohlaví je povinné")]
        public int EGenderId { get; set; }

        [Required(ErrorMessage = "Jméno je povinné")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Příjmení je povinné")]
        public string SurName { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        //[EmailAddress]
        [Display(Name = "Uživatelské jméno")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí obsahovat minimálně {2} znaků.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrzení hesla")]
        [Compare("Password", ErrorMessage = "Heslo se neshoduje s potvrzením hesla.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        //[EmailAddress]
        [Display(Name = "Uživatelksé jméno")]
        public string Email { get; set; }
    }

    public class PartialLinkedUserbasics
    {
        public string Id;
        public string fullName;

        public string photoUrl= "https://media1.giphy.com/media/mFdnWF1RTI7fi/giphy.gif";
        public string imgSize = "xxs";
        public PartialLinkedUserbasics(MujZavod.Data.Identity.ApplicationUser user)
        {
            Load(user, "xxs");
        }

        public PartialLinkedUserbasics(MujZavod.Data.Identity.ApplicationUser user,string imgSize)
        {
            Load(user,imgSize);
        }

        public void Load(MujZavod.Data.Identity.ApplicationUser user, string imgSize)
        {
            Id = user.Id;
            fullName = MujZavod.Code.Repository.ApplicationUserRepository.GetFullName(user);
            
            this.imgSize = imgSize;
        }
    }

}
