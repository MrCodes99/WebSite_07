using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSite_Semana07.Startup))]
namespace WebSite_Semana07
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
