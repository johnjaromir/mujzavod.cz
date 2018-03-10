using MujZavod.Admin.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Mvc;

namespace MujZavod.Admin.Controllers
{
    [Authorize]
    [Authorize(Roles = "Organizer")]
    public class BaseController : Controller
    {
        protected Data.Identity.ApplicationUser CurrentUser;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ResourceManager rm = ControllerActionNames.ResourceManager;
            string controllerName = filterContext.RouteData.Values["controller"].ToString();
            string actionName = filterContext.RouteData.Values["action"].ToString();

            ViewBag.Title = rm.GetString(controllerName + "_" + actionName);
            ViewBag.ControllerTitle = rm.GetString(controllerName);

            


            //Nastavení aplikace*******************************************************
            ViewBag.AppName = "Sonus Admin";
            ViewBag.AppLogo = "/Content/img/header-logo.png";
            ViewBag.AppLogoSm = "/Content/img/header-logo-sm.png";
            //*************************************************************************



            base.OnActionExecuting(filterContext);
        }
    }
}