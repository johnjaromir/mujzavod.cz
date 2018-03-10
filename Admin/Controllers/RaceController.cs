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

            return PartialView();
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
                race.Description = model.Description;
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

            return View(new Models.Race.RaceViewModel(race));
        }
    }
}