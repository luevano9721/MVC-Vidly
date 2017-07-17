using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC2._0.Startup))]
namespace MVC2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
