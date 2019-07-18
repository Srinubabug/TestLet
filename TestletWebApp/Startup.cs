using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestletWebApp.Startup))]
namespace TestletWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
