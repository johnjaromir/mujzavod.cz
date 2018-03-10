using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Code.MailTools
{
    public class SmtpPipe
    {
        private static SmtpPipe _instance;
        public static SmtpPipe Instance => _instance ?? (_instance = new SmtpPipe());


        public void SendWelcomeEmail(Data.Identity.ApplicationUser user)
        {
            Core.Instance.sendHTMLMail(user.Email, "Vítejte na MůjZávod.cz",
                $"Právě jste se zaregistrovali na {System.Web.Configuration.WebConfigurationManager.AppSettings.Get("webUrl")}");
        }
    }
}
