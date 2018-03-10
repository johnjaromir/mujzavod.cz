using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Code.MailTools
{


    public class MailConfig : ConfigurationSection
    {
        private static MailConfig _Instance = ConfigurationManager.GetSection("MailConfig") as MailConfig;

        public static MailConfig Instance => _Instance;

        private MailConfig()
        {

        }

        [ConfigurationProperty("server", IsRequired = true)]
        public string Server => (string)this["server"];
        
        [ConfigurationProperty("userName", IsRequired = true)]
        public string UserName => (string)this["userName"];

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password => (string)this["password"];

        [ConfigurationProperty("port", IsRequired = true)]
        public int Port => (int)this["port"];

        [ConfigurationProperty("ssl", IsRequired = true)]
        public bool Ssl => (bool)this["ssl"];

        [ConfigurationProperty("mail", IsRequired = true)]
        public string Mail => (string)this["mail"];

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name => (string)this["name"];
    }
        
}
