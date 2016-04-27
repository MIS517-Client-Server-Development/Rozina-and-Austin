using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityManagementApp.Startup))]
namespace UniversityManagementApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
