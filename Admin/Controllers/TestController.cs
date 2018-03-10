using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MujZavod.Admin.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult SendMail()
        {
            
            return Content(Code.MailTools.Core.Instance.sendHTMLMail("johnjaromir@gmail.com", "test", "teeest").ToString());
        }
    }
}