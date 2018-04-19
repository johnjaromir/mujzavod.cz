using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MujZavod.Code.Repository;

namespace MujZavod.Admin.Controllers
{
    

    public class RunnerController : Controller
    {

        RaceRepository _RaceRepository;
        RaceRepository RaceRepository => _RaceRepository ?? (_RaceRepository = new RaceRepository());

        RaceCategoryRepository _RaceCategoryRepository;
        RaceCategoryRepository RaceCategoryRepository => _RaceCategoryRepository ?? (_RaceCategoryRepository = new RaceCategoryRepository());

        RaceCategoryUsersRepository _RaceCategoryUsersRepository;
        RaceCategoryUsersRepository RaceCategoryUsersRepository => _RaceCategoryUsersRepository ?? (_RaceCategoryUsersRepository = new RaceCategoryUsersRepository());

        public ActionResult Index()
        {
            return View(new Models.Runner.RunnerRaceGridViewModel());
        }

        public ActionResult RunnerRacesGridData()
        {

            return Json(Helpers.GridHelper.ToGridData(
                RaceCategoryUsersRepository.GetAllByUser(
                    new ApplicationUserRepository().GetActAu().Id),
                    x=> new Models.Runner.RunnerRaceGridRow(x)
                ), JsonRequestBehavior.AllowGet);
        }
    }
}