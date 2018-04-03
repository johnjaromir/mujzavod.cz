using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MujZavod.Admin.Helpers;


namespace MujZavod.Admin.Controllers
{
    public class RaceController : AccountController
    {
        private Code.Repository.RaceRepository _RaceRepository;
        private Code.Repository.RaceRepository RaceRepository => _RaceRepository ?? (_RaceRepository = new Code.Repository.RaceRepository());

        private Code.Repository.RaceCategoryRepository _RaceCategoryRepository;
        private Code.Repository.RaceCategoryRepository RaceCategoryRepository => _RaceCategoryRepository ?? (_RaceCategoryRepository = new Code.Repository.RaceCategoryRepository());

        private Code.Repository.EGenderRepository _EGenderRepository;
        private Code.Repository.EGenderRepository EGenderRepository => _EGenderRepository ?? (_EGenderRepository = new Code.Repository.EGenderRepository());

        private Code.Repository.RaceRoundRepository _RaceRoundRepository;
        private Code.Repository.RaceRoundRepository RaceRoundRepository => _RaceRoundRepository ?? (_RaceRoundRepository = new Code.Repository.RaceRoundRepository());

        private Code.Repository.ApplicationUserRepository _ApplicationUserRepository;
        private Code.Repository.ApplicationUserRepository ApplicationUserRepository => _ApplicationUserRepository ?? (_ApplicationUserRepository = new Code.Repository.ApplicationUserRepository());

        private Code.Repository.RaceSubCategoryRepository _RaceSubCategoryRepository;
        private Code.Repository.RaceSubCategoryRepository RaceSubCategoryRepository => _RaceSubCategoryRepository ?? (_RaceSubCategoryRepository = new Code.Repository.RaceSubCategoryRepository());

        private Code.Repository.RaceCategoryUsersRepository _RaceCategoryUsersRepository;
        private Code.Repository.RaceCategoryUsersRepository RaceCategoryUsersRepository => _RaceCategoryUsersRepository ?? (_RaceCategoryUsersRepository = new Code.Repository.RaceCategoryUsersRepository());

        // GET: Race
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GridData()
        {
            
            return Json(RaceRepository.GetAll().ToGridData(x=> new Models.Race.RaceGridRow(x)), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Models.Race.RaceViewModel model;

            if (id.HasValue)
                model = new Models.Race.RaceViewModel(RaceRepository.GetById(id.Value));
            else
                model = new Models.Race.RaceViewModel();

            return PartialView(model);
        }


        [HttpPost]
        public ActionResult Edit(Models.Race.RaceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Data.Models.Race race;

                if (!model.Id.HasValue)
                {
                    race = new Data.Models.Race();
                    race.OrganizerId = actUser.OrganizerId.Value;
                }
                else
                    race = RaceRepository.GetById(model.Id.Value);


                race.Name = model.Name;
                race.Description = model.RaceDescription;
                race.Date = model.Date.Value;
                race.SignToDate = model.SignToDate.Value;

                if (model.Id.HasValue)
                    RaceRepository.Update(race, true);
                else
                    RaceRepository.Create(race, true);

                return Content("OK");
            }
            return PartialView(model);
        }


        public ActionResult Detail(int id)
        {
            var race = RaceRepository.GetById(id);

            return View(new Models.Race.RaceDetailModel(race));
        }

        public ActionResult Head(int id)
        {
            
            return PartialView(new Models.Race.RaceViewModel(RaceRepository.GetById(id)));
        }

        

        [HttpGet]
        public ActionResult CategoryEdit(int? id, int raceId)
        {
            Models.Race.RaceCategory.RaceCategoryViewModel model;

            if (id.HasValue)
                model = new Models.Race.RaceCategory.RaceCategoryViewModel(RaceCategoryRepository.GetById(id.Value));
            else
                model = new Models.Race.RaceCategory.RaceCategoryViewModel() { RaceId = raceId };

            return PartialView("/Views/Race/Category/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult CategoryEdit(Models.Race.RaceCategory.RaceCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Data.Models.RaceCategory raceCategory;

                if (!model.Id.HasValue)
                {
                    raceCategory = new Data.Models.RaceCategory();
                    raceCategory.RaceId = model.RaceId;
                }
                else
                    raceCategory = RaceCategoryRepository.GetById(model.Id.Value);


                raceCategory.Name = model.Name;
                raceCategory.Description = model.Description;
                raceCategory.Start = model.Start.Value;
                
                if (model.Id.HasValue)
                    RaceCategoryRepository.Update(raceCategory, true);
                else
                    RaceCategoryRepository.Create(raceCategory, true);

                return Content("OK");
            }
            return PartialView("/Views/Race/Category/Edit.cshtml", model);
        }



        public ActionResult RoundGridData(int id)
        {
            return Json(RaceRoundRepository.GetAll().Where(x=>x.RaceCategoryId == id).ToGridData(x => new Models.Race.RaceCategory.Round.RoundGridRow(x)), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CategoryRoundEdit(int? id, int raceCategoryId)
        {
            Models.Race.RaceCategory.Round.RoundViewModel model;

            if (id.HasValue)
                model = new Models.Race.RaceCategory.Round.RoundViewModel(RaceRoundRepository.GetById(id.Value));
            else
                model = new Models.Race.RaceCategory.Round.RoundViewModel() { RaceCategoryId = raceCategoryId };

            return PartialView("/Views/Race/Category/Round/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult CategoryRoundEdit(Models.Race.RaceCategory.Round.RoundViewModel model)
        {
            if (ModelState.IsValid)
            {
                Data.Models.RaceRound raceRound;

                if (!model.Id.HasValue)
                {
                    raceRound = new Data.Models.RaceRound();
                    raceRound.RaceCategoryId = model.RaceCategoryId;
                }
                else
                    raceRound = RaceRoundRepository.GetById(model.Id.Value);


                raceRound.Name = model.Name;
                raceRound.Distance = model.Distance;

                
                if (model.Id.HasValue)
                    RaceRoundRepository.Update(raceRound, true);
                else
                    RaceRoundRepository.Create(raceRound, true);

                return Content("OK");
            }
            return PartialView("/Views/Race/Category/Round/Edit.cshtml", model);
        }


        public ActionResult RaceRunnersGridData(int raceCategoryId)
        {
            return Json(RaceCategoryUsersRepository.getUsers(raceCategoryId)
                .ToGridData(x => new Models.Race.RaceCategory.RaceRunners.RaceRunnersGridRow(x)),
                JsonRequestBehavior.AllowGet);
        }


        public ActionResult SubCategoryGridData(int raceCategoryId)
        {
            return Json(RaceSubCategoryRepository.GetAll().Where(x=>x.RaceCategoryId == raceCategoryId)
                .ToGridData(x => new Models.Race.RaceCategory.SubCategory.SubCategoryGridRow(x)),
                JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult SubCategoryEdit(int? id, int raceCategoryId)
        {
            Models.Race.RaceCategory.SubCategory.SubCategoryViewModel model;

            if (id.HasValue)
                model = new Models.Race.RaceCategory.SubCategory.SubCategoryViewModel(RaceSubCategoryRepository.GetById(id.Value));
            else
                model = new Models.Race.RaceCategory.SubCategory.SubCategoryViewModel() { RaceCategoryId = raceCategoryId };

            return PartialView("/Views/Race/Category/SubCategory/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult SubCategoryEdit(Models.Race.RaceCategory.SubCategory.SubCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Data.Models.RaceSubCategory raceSubCategory;

                if (!model.Id.HasValue)
                {
                    raceSubCategory = new Data.Models.RaceSubCategory();
                    raceSubCategory.RaceCategoryId = model.RaceCategoryId;
                }
                else
                    raceSubCategory = RaceSubCategoryRepository.GetById(model.Id.Value);


                raceSubCategory.Name = model.Name;

                raceSubCategory.AgeFrom = model.AgeFrom;
                raceSubCategory.AgeTo = model.AgeTo;


                
                if (model.SelectedGenders != null)
                {
                    
                    var items = raceSubCategory.AllowedGenders.ToList();
                    foreach (var item in items)
                    {
                        if (!model.SelectedGenders.Contains(item.Id.ToString()))
                            raceSubCategory.AllowedGenders.Remove(item);
                    }

                    foreach (var item in model.SelectedGenders)
                    {
                        if (raceSubCategory.AllowedGenders.Count(x => x.Id == Convert.ToInt32(item)) == 0)
                            raceSubCategory.AllowedGenders.Add(EGenderRepository.GetById(Convert.ToInt32(item)));
                    }
                }
                else
                {
                    var items = raceSubCategory.AllowedGenders.ToList();
                    foreach (var item in items)
                    {
                        raceSubCategory.AllowedGenders.Remove(item);
                    }
                }
                





                if (model.Id.HasValue)
                    RaceSubCategoryRepository.Update(raceSubCategory, true);
                else
                    RaceSubCategoryRepository.Create(raceSubCategory, true);

                return Content("OK");
            }
            return PartialView("/Views/Race/Category/SubCategory/Edit.cshtml", model);
        }



        [HttpGet]
        public ActionResult SubCategoryUserEdit(string id, int? raceCategoryId)
        {
            Models.User.NotRegistered.NotRegisteredViewModel model;
            if (!string.IsNullOrWhiteSpace(id))
                model = new Models.Race.RaceCategory.RaceRunners.RaceRunnerEditViewModel(RaceCategoryUsersRepository.GetById(Convert.ToInt32(id)));
            else
                model = new Models.Race.RaceCategory.RaceRunners.RaceRunnerEditViewModel()
                {
                    RaceCategoryId = raceCategoryId,
                    RaceSubCategoryDropDownModel = new Models.DropDown.RaceSubCategoryDropDownModel(raceCategoryId.Value)
                };
        
            return PartialView("/Views/Race/Category/SubCategory/EditUser.cshtml", model);
        }

        public ActionResult SubCategoryUserEdit(Models.Race.RaceCategory.RaceRunners.RaceRunnerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Data.Models.RaceCategoryUser raceCategoryUser;
                Data.Identity.ApplicationUser au;
                if (!string.IsNullOrWhiteSpace(model.Id))
                {
                    raceCategoryUser = RaceCategoryUsersRepository.GetById(Convert.ToInt32(model.Id));
                    au = raceCategoryUser.ApplicationUser;
                }
                else
                {
                    raceCategoryUser = new Data.Models.RaceCategoryUser();
                    au = new Data.Identity.ApplicationUser();
                }

                au.FirstName = model.FirstName;
                au.LastName = model.LastName;
                au.EGenderId = model.GenderId;
                au.BirthDate = model.BirthDate.Value;

                raceCategoryUser.RunnerNumber = model.RunnerNumber;
                raceCategoryUser.RaceSubCategoryId = model.RaceSubCategoryId;

                if (!string.IsNullOrWhiteSpace(model.Id))
                {
                    ApplicationUserRepository.Update(au, false);
                    RaceCategoryUsersRepository.Update(raceCategoryUser, true);
                }
                else
                {
                    au.UserName = Guid.NewGuid().ToString();
                    ApplicationUserRepository.Create(au, false);

                    raceCategoryUser.ApplicationUserId = au.Id;
                    raceCategoryUser.RaceCategoryId = model.RaceCategoryId.Value;
                   
                    
                    RaceCategoryUsersRepository.Create(raceCategoryUser, true);
                }
                return Content("OK");
            }
            return PartialView("/Views/Race/Category/SubCategory/EditUser.cshtml", model);
        }



        public ActionResult Publish(int raceId)
        {
            var race = RaceRepository.GetById(raceId);

            if (race.OrganizerId == actUser.OrganizerId)
            {
                race.PublishDate = DateTime.Now;
                race.RaceKey = Guid.NewGuid().ToString().Replace("-", "");
                RaceRepository.Update(race, true);
            }

            return Content("OK");
        }



        [HttpGet]
        public ActionResult EditUserTimes(int runnerId)
        {
            var model = new Models.Race.RaceCategory.RaceRunners.RaceRunnerTimes(RaceCategoryUsersRepository.GetById(runnerId));
            return PartialView("/Views/Race/Category/SubCategory/EditUserTimes.cshtml", model);
        }

        [HttpPost]
        public ActionResult EditUserTimes(Models.Race.RaceCategory.RaceRunners.RaceRunnerTimes model)
        {
            var runner = RaceCategoryUsersRepository.GetById(model.RaceRunnerId);

            var repo = new Code.Repository.RaceRoundUsersRepository();

            foreach(var roundTime in model.RaceRunnersTimeRounds)
            {
                var round = runner.RaceRoundUsers.Where(x => x.RaceRoundId == roundTime.RoundId).FirstOrDefault();

                if (round == null)
                {
                    round = new Data.Models.RaceRoundUser()
                    {
                        RaceCategoryUserId = runner.Id,
                        RaceRoundId = roundTime.RoundId,
                        Time = roundTime.Time.Value
                    };
                    repo.Create(round, true);
                }
                else
                {
                    round.Time = roundTime.Time.Value;
                    repo.Update(round, true);
                }
            }

            return Content("OK");
        }

        public ActionResult EndRace(int RaceId)
        {
            var race = RaceRepository.GetById(RaceId);
            race.EndDate = DateTime.Now;
            RaceRepository.Update(race, true);
            return Content("OK");
        }
    }
}