using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LucidDreamer.Startup))]
namespace LucidDreamer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
