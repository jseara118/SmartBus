using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartBus.Startup))]
namespace SmartBus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
