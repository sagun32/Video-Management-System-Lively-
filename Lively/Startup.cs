using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lively.Startup))]
namespace Lively
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
