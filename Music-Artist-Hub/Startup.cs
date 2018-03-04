using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Music_Artist_Hub.Startup))]
namespace Music_Artist_Hub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
