using System.Web.Http;

namespace DeusVultOnline.Controllers
{
    [RoutePrefix("api/main")]
    public class MainController : BaseController
    {
        [Route("string")]
        [HttpGet]
        public string GetString()
        {
            return "Hello World";
        }
    }
}