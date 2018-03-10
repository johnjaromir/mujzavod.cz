using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Web;

namespace MujZavod.Code.MailTools
{
    

    
    public class Core
    {
        private static Core _Instance;
        public static Core Instance => _Instance ?? (_Instance = new Core());




        string server;
        int port;

        string mail;
        string user;
        string pass;
        string name;

        bool ssl;

        System.Net.NetworkCredential netwrkCrd;

        public Core()
        {
            server = MailConfig.Instance.Server;
            user = MailConfig.Instance.UserName;
            pass = MailConfig.Instance.Password;
            port = MailConfig.Instance.Port;

            mail = MailConfig.Instance.Mail;
            name = MailConfig.Instance.Name;
            ssl = MailConfig.Instance.Ssl;

            netwrkCrd = new System.Net.NetworkCredential();
            netwrkCrd.UserName = user;
            netwrkCrd.Password = pass;
            //netwrkCrd.Domain = "aprb.local";

        }

        

        public bool sendHTMLMail(string to, string subject, string body)
        {
            //MailMessage mailObj = new MailMessage(
            //    mail, to, subject, body);

            MailMessage mailObj = new MailMessage(new MailAddress(mail, name), new MailAddress(to));
            mailObj.Subject = subject;
            mailObj.Body = body;
            mailObj.IsBodyHtml = true;

            

            SmtpClient SMTPServer = new SmtpClient(server, port);
            try
            {
                SMTPServer.EnableSsl = ssl;
                SMTPServer.Credentials = netwrkCrd;
                SMTPServer.Send(mailObj);
            }
            catch (Exception e)
            {

            }

            return true;
        }


       
        

    }
    
}
