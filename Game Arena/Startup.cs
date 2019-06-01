using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Game_Arena.Startup))]
namespace Game_Arena
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
