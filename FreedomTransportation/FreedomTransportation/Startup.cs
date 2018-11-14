using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FreedomTransportation.Startup))]
namespace FreedomTransportation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
