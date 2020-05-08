using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlottedAssist.Startup))]
namespace PlottedAssist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
