using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MujZavod.Admin.Controllers
{
    [Authorize(Roles = "Organizer")]
    public class OrganizerController : AccountController
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View(new Models.Organizer.CreateViewModel());
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> RegisterOrganizer(Models.Organizer.CreateViewModel model)
        {
            if (ModelState.IsValid)
            {

                Data.DataDbContext context = new Data.DataDbContext();

                var user = new Data.Identity.ApplicationUser { UserName = model.registerViewModel.Email,
                    Email = model.registerViewModel.Email, FirstName = model.registerViewModel.FirstName, LastName = model.registerViewModel.SurName,
                    EGenderId = model.registerViewModel.EGenderId, BirthDate = model.registerViewModel.BirthDate, LockoutEnabled = false };
                
                var result = await UserManager.CreateAsync(user, model.registerViewModel.Password);
                if (result.Succeeded)
                {
                    await UserManager.SetLockoutEnabledAsync(user.Id, false);
                    await UserManager.AddToRoleAsync(user.Id, "Organizer");

                    var organizer = new Data.Models.Organizer()
                    {
                        Name = model.organizerViewModel.Name,
                        Description = model.organizerViewModel.Description
                    };
                    var usr = new Code.Repository.ApplicationUserRepository().GetById(user.Id);
                    organizer.Organizers.Add(usr);
                    
                    
                    new Code.Repository.OrganizerRepository().Create(organizer, true);

                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    Code.MailTools.SmtpPipe.Instance.SendWelcomeEmail(user);
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            return View("/Views/Organizer/Register.cshtml",model);
        }

    }
}