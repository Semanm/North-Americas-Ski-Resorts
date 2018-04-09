using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NASR.Startup))]
namespace NASR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
