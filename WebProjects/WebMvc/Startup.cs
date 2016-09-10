using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMvc.Startup))]
namespace WebMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
