using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MickyPepa_Market.Startup))]
namespace MickyPepa_Market
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
