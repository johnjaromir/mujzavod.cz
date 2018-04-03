using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MujZavod.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MujZavod.Admin.Controllers
{
    public class RaceRegistrationController : Controller
    {
        private Code.Repository.RaceRepository _RaceRepository;
        private Code.Repository.RaceRepository RaceRepository => _RaceRepository ?? (_RaceRepository = new Code.Repository.RaceRepository());

        private Code.Repository.ApplicationUserRepository _ApplicationUserRepository;
        private Code.Repository.ApplicationUserRepository ApplicationUserRepository => _ApplicationUserRepository ?? (_ApplicationUserRepository = new Code.Repository.ApplicationUserRepository());


        private Code.Repository.RaceCategoryRepository _RaceCategoryRepository;
        private Code.Repository.RaceCategoryRepository RaceCategoryRepository => _RaceCategoryRepository ?? (_RaceCategoryRepository = new Code.Repository.RaceCategoryRepository());

        private Code.Repository.RaceSubCategoryRepository _RaceSubCategoryRepository;
        private Code.Repository.RaceSubCategoryRepository RaceSubCategoryRepository => _RaceSubCategoryRepository ?? (_RaceSubCategoryRepository = new Code.Repository.RaceSubCategoryRepository());

        private Code.Repository.RaceCategoryUsersRepository _RaceCategoryUsersRepository;
        private Code.Repository.RaceCategoryUsersRepository RaceCategoryUsersRepository => _RaceCategoryUsersRepository ?? (_RaceCategoryUsersRepository = new Code.Repository.RaceCategoryUsersRepository());



        /// <summary>
        /// Povolení cross site .. budeme to vkládat někam..
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            base.OnActionExecuting(filterContext);
        }



        
       
        
        public ActionResult Index(string Id)
        {
            var race = RaceRepository.getRaceByKeyDetail(Id);
            return View(new Models.RaceRegistration.RaceRegistrationViewModel(race));
        }

        [HttpGet]
        public ActionResult RegisterOnRace(string raceKey)
        {
            var race = RaceRepository.getRaceByKey(raceKey);
            return PartialView(new Models.RaceRegistration.RegisterOnRaceViewModel(race));
        }

        [HttpPost]
        public ActionResult RegisterOnRace(Models.RaceRegistration.RegisterOnRaceViewModel model)
        {
            ApplicationUser au;
            if (model.RegistrationTypeId == 1)
            {
                au = UserManager.Find(model.EmailLogin, model.PasswordLogin);
            }
            else
            {
                au = new ApplicationUser
                {
                    
                    Email = model.Email,
                    EGenderId = model.EGenderId,
                    BirthDate = Convert.ToDateTime(model.BirthDate),
                    FirstName = model.FirstName,
                    LastName = model.SurName
                };

                if (model.CreateAccount)
                {
                    au.UserName = model.Email;
                    UserManager.Create(au, model.Password);
                    UserManager.SetLockoutEnabled(au.Id, false);
                    UserManager.AddToRoleAsync(au.Id, "User");
                }
                else
                {
                    au.UserName = Guid.NewGuid().ToString();
                    ApplicationUserRepository.Create(au, false);
                }
            }

            if (au != null)
            {
                Data.Models.RaceCategoryUser raceCategoryUser = new Data.Models.RaceCategoryUser()
                {
                    ApplicationUserId = au.Id,
                    RaceCategoryId = model.RaceCategoryId,
                    RaceSubCategoryId = model.RaceSubCategoryId
                };
                RaceCategoryUsersRepository.Create(raceCategoryUser, true);
            }

            return Content("OK");
        }

        public ActionResult CheckLogin(string email, string password)
        {
            var user = UserManager.Find(email, password);

            if (user != null)
                return Json(new { Success = true, User = new { EGenderId = user.EGenderId, BirthDate = user.BirthDate.ToString() } }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Success = false, Err = "Nesprávné jméno/heslo" });
        }

        public ActionResult CheckFreeLogin(string email)
        {
            return Content(ApplicationUserRepository.isUsernameFree(email) ? "OK" : "Na daný email je již účet vytvořen.");
        }

        public ActionResult GetCategoryForUser(string raceKey, int genderId, string birthDate)
        {
            var categories = RaceCategoryRepository.GetCategoryForUser(raceKey, genderId, Convert.ToDateTime(birthDate));
            return Json( categories.Select(x => new { key= x.Id, value = x.Name }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubCategoryForUser(int genderId, string birthDate, int raceCategoryId)
        {
            var categories = RaceSubCategoryRepository.GetSubCategoryForUser(genderId, Convert.ToDateTime(birthDate), raceCategoryId);
            return Json(categories.Select(x => new { key = x.Id, value = x.Name }), JsonRequestBehavior.AllowGet);
        }



        public ActionResult Detail(string raceKey)
        {
            var race = RaceRepository.getRaceByKey(raceKey);
            return View(new Models.RaceRegistration.RaceRegistrationViewModel(race));
        }





        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}