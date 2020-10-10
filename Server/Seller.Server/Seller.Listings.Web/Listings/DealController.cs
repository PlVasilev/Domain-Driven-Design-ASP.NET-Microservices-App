using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seller.Listings.Application.Listings.Deals.Commands.Create;
using Seller.Listings.Application.Listings.Deals.Queries.BuyDeals;
using Seller.Listings.Application.Listings.Deals.Queries.Common;

namespace Seller.Listings.Web.Listings
{
    [Authorize]
    public class DealController : ApiController
    {

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<bool>> Create(CreateDealCommand command) => await
            this.Send(command);

        [HttpGet]
        [Route("BuyDeals/{id}")]
        public async Task<ActionResult<IReadOnlyList<DealResponseModel>>> BuyDeals([FromRoute] AllSellDealsQuery query)
            => await Send(query);
            

        [HttpGet]
        [Route("SaleDeals/{id}")]
        public async Task<ActionResult<IReadOnlyList<DealResponseModel>>> SaleDeals([FromRoute] AllSellDealsQuery query)
            => await Send(query);


    }
}
