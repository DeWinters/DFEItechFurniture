using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DFEItechFurniture.Startup))]
namespace DFEItechFurniture
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
