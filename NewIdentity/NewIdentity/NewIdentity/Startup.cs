using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewIdentity.Startup))]
namespace NewIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
