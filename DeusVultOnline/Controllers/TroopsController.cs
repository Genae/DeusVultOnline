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
                var testReg = new Regiment100();
                testGroup.AddChild(testReg);
                testReg.Fromation = new TurtleFormation();
                for (int i = 0; i < 100; i++)
                {
                    testReg.Units.Add(new Unit()
                    {
                        Attack = 1
                    });
                }
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