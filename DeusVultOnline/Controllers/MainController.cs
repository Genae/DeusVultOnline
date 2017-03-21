using System.Web.Http;

namespace DeusVultOnline.Controllers
{
    [RoutePrefix("api/main")]
    public class MainController : ApiController
    {
        [Route("string")]
        [HttpGet]
        public string GetString()
        {
            return "Hello World";
        }
    }
}