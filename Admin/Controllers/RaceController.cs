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
                race.Date = model.Date;
                race.SignToDate = model.SignToDate;

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
                //raceCategory.AgeFrom = model.AgeFrom;
                //raceCategory.AgeTo = model.AgeTo;


                /*
                if (model.SelectedGenders != null)
                {
                    
                    var items = raceCategory.AllowedGenders.ToList();
                    foreach (var item in items)
                    {
                        if (!model.SelectedGenders.Contains(item.Id.ToString()))
                            raceCategory.AllowedGenders.Remove(item);
                    }

                    foreach (var item in model.SelectedGenders)
                    {
                        if (raceCategory.AllowedGenders.Count(x => x.Id == Convert.ToInt32(item)) == 0)
                            raceCategory.AllowedGenders.Add(EGenderRepository.GetById(Convert.ToInt32(item)));
                    }
                }
                else
                {
                    var items = raceCategory.AllowedGenders.ToList();
                    foreach (var item in items)
                    {
                        raceCategory.AllowedGenders.Remove(item);
                    }
                }
                */





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
            return PartialView("/Views/Race/Category/Edit.cshtml", model);
        }

    }
}