using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Voorraadsysteem_ToolsForEver.Startup))]
namespace Voorraadsysteem_ToolsForEver
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
