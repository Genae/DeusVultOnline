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
            var battlefield = new Battlefield(50);

            var tile = battlefield.BattlefieldTiles[0, 0];
            var ulist = new List<UnitGroup>();
            ulist.Add(new UnitGroup(new UnitType(new Inventory(), 1), 100));
            tile.Regiment = new Regiment100(ulist);


            var tile2 = battlefield.BattlefieldTiles[0, 1];
            var ulist2 = new List<UnitGroup>();
            ulist2.Add(new UnitGroup(new UnitType(new Inventory(), 1), 100));
            tile2.Regiment = new Regiment100(ulist2);


            var list = battlefield.GetPositionsInRange(tile);
        }
    }
}