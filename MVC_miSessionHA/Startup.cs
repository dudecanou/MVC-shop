using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_miSessionHA.Startup))]
namespace MVC_miSessionHA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
