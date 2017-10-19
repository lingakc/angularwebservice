using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(angularwebservice.Startup))]
namespace angularwebservice
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
