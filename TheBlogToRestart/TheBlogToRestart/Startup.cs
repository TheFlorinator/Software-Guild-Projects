using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheBlogToRestart.Startup))]
namespace TheBlogToRestart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
