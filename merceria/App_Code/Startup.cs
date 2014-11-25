using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(merceria.Startup))]
namespace merceria
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
