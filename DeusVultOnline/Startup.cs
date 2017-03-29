using System.Collections.Generic;
using System.Web.Http;
using DeusVultOnline.Authentication;
using DeusVultOnline.Battleground;
using DeusVultOnline.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(DeusVultOnline.Startup))]

namespace DeusVultOnline
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            app.CreatePerOwinContext<UserManager>(UserManager.Create);
            app.CreatePerOwinContext<SignInManager>(SignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/"),
                Provider = new CookieAuthenticationProvider()
            });
            app.UseWebApi(config);
            app.MapSignalR();

            TestShit();//DEBUG SHIT
        }

        private void TestShit()//YEY
        {
            var battlefield = new Battlefield(9);

            var tile = battlefield.BattlefieldTiles[5, 5];
            tile.Regiment = new Regiment100();
            var reg = tile.Regiment;
            reg.Units = new List<Unit>();
            reg.Units.Add(new Unit());
            reg.Units[0].Movement = 5;

            /*var tile2 = battlefield.BattlefieldTiles[0, 0];
            tile2.Regiment = new Regiment100();
            var reg2 = tile.Regiment;
            reg2.Units = new List<Unit>();
            reg2.Units.Add(new Unit());
            reg2.Units[0].Movement = 1;*/


            var list = battlefield.GetPositionsInRange(tile);
            //PRIME EXAMPLE OF WHAT HAPPENS IF YOU USE BLACK MAGIC, IT IS JUST EVIL STEFAN PLS EXPLAIN
            //who needs constructors anyways : >
        }
    }
}