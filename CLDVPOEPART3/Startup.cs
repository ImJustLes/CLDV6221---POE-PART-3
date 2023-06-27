using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CLDVPOEPART3.Startup))]
namespace CLDVPOEPART3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
