using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerMVCApp.Startup))]
namespace CustomerMVCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
