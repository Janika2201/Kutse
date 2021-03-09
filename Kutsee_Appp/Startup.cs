using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kutsee_Appp.Startup))]
namespace Kutsee_Appp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
