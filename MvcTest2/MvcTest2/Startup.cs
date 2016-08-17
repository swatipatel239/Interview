using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcTest2.Startup))]
namespace MvcTest2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
