using Microsoft.AspNetCore.Mvc;

namespace Seller.Shared.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Works");
        }
    }
}
