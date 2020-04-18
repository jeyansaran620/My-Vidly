using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(My_Vidly.Startup))]
namespace My_Vidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
