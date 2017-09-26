using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(marshall_clio_audio.Startup))]
namespace marshall_clio_audio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
