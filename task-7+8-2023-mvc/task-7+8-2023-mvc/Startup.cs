using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(task_7_8_2023_mvc.Startup))]
namespace task_7_8_2023_mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
