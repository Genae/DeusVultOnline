using System.Linq;
using System.Web.Http;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DeusVultOnline.Controllers
{
    [RoutePrefix("api/fight")]
    public class FightController : ApiController
    {
        [Route("start")]
        [HttpPost]
        public Fight StartFight(StartFightContract sfc)
        {
            var fight = new Fight();
            fight.Save();
            return fight;
        }

        [Route("{id}")]
        [HttpGet]
        public Fight GetFight(string id)
        {
            var objId = ObjectId.Parse(id);
            var fight = Repository.Instance.GetCollection<Fight>().FindSync(o => o.Id == objId).FirstOrDefault();
            return fight;
        }
    }

    public class StartFightContract
    {
        public ObjectId TroopsPlayer1 { get; set; }
        public ObjectId TroopsPlayer2 { get; set; }
    }

    public class Fight : KeyedDocument<Fight>
    {

    }

    public abstract class KeyedDocument<T> where T:KeyedDocument<T>
    {
        public ObjectId Id { get; set; }

        public void Save()
        {
            if (Repository.Instance.GetCollection<T>().AsQueryable().Any(o => o.Id == Id))
            {
                Repository.Instance.GetCollection<T>().ReplaceOne(new FilterDefinitionBuilder<T>().Eq(o => o.Id, Id), this as T);
            }
            else
            {
                Repository.Instance.GetCollection<T>().InsertOne(this as T);
            }
        }
    }
}