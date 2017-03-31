using System.Collections.Generic;
using System.Web.Http;
using DeusVultOnline.Models;

namespace DeusVultOnline.Controllers
{
    [RoutePrefix("api/troops")]
    public class TroopsController : ApiController
    {
        [Route("formation")]
        [HttpGet]
        public Formation[] GetFormations()
        {
            return new Formation[] {new TurtleFormation()};
        }

        [Route("armyGroup/{id}")]
        public ArmyGroup GetArmyGroup(string id)
        {
            //var objId = ObjectId.Parse(id);
            var testGroup = new Regiment500();
            for (var j = 0; j < 5; j++)
            {
                var ulist = new List<UnitGroup>();
                ulist.Add(new UnitGroup(new UnitType(new Inventory(), 1), 100));
                var testReg = new Regiment100(ulist);

                testGroup.AddChild(testReg);
                testReg.Fromation = new TurtleFormation();
            }
            return testGroup;
        }

        [Route("items")]
        [HttpGet]
        public Item[] GetItems()
        {
            return new ItemProvider().Weapons;
        }
    }
}