using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seller.Listings.Application.Listings.UserSellers.Commands.Create;
using Seller.Listings.Application.Listings.UserSellers.Queries.GetByUserId;

namespace Seller.Listings.Web.Listings
{
    
    public class SellerController : ApiController
    {

        [Authorize]
        [HttpGet]
        [Route("Id")]
        public async Task<ActionResult<SellerIdResponseModel>> GetSellerId([FromRoute] UserSellerGetByUserIdQuery query) =>
            await Send(query);


        [Authorize]
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
