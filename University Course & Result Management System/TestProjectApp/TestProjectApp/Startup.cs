using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestProjectApp.Startup))]
namespace TestProjectApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
