using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inventory_Management_Systems.Startup))]
namespace Inventory_Management_Systems
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
