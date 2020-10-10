using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seller.Listings.Application.Listings.UserSellers.Commands.Create;
using Seller.Listings.Application.Listings.UserSellers.Queries.GetByUserId;

namespace Seller.Listings.Web.Listings
{
    [Authorize]
    public class SellerController : ApiController
    {


        [HttpGet]
        [Route("Id")]
        public async Task<ActionResult<SellerIdResponseModel>> GetSellerId(UserSellerGetByUserIdQuery query) =>
            await Send(query);



        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create(CreateUserSellerCommand command)
        {
            var result = await Send(command);
            if (result.Value) return Ok();
            return BadRequest();
        }

    }
}
