using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Essentialbooks.Startup))]
namespace Essentialbooks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
