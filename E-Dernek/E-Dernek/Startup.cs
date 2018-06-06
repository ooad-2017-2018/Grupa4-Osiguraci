using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_Dernek.Startup))]
namespace E_Dernek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
