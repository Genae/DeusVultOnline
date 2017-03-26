using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DeusVultOnline.Startup))]

namespace DeusVultOnline
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}