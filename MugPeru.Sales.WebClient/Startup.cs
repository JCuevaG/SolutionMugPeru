using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MugPeru.Sales.WebClient.Startup))]
namespace MugPeru.Sales.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
