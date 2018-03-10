using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MujZavod.Admin.Startup))]
namespace MujZavod.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
