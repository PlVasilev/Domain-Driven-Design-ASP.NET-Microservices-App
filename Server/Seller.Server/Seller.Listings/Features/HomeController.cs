using Seller.Shared.Controllers;

namespace Seller.Listings.Features
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : ApiController
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Works");
        }
    }
}
