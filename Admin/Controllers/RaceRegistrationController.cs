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

        public ActionResult IframeButton(string raceKey)
        {
            var race = RaceRepository.getRaceByKey(raceKey);
            return View(new Models.RaceRegistration.RaceRegistrationViewModel(race));
        }
    }
}