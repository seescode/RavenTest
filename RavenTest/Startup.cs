using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RavenTest.Startup))]
namespace RavenTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
