using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnitTestingDemo.Startup))]
namespace UnitTestingDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
