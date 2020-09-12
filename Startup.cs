using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Paranoid.Startup))]
namespace Paranoid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
