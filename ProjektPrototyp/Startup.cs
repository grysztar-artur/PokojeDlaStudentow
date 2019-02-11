using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjektPrototyp.Startup))]
namespace ProjektPrototyp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
