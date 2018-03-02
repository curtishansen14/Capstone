using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CapStone.Startup))]
namespace CapStone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
