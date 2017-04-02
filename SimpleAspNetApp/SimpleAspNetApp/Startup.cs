using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleAspNetApp.Startup))]
namespace SimpleAspNetApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
