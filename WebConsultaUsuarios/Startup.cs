using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebConsultaUsuarios.Startup))]
namespace WebConsultaUsuarios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
