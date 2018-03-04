using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NorthAmericasSkiResorts.Startup))]
namespace NorthAmericasSkiResorts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
