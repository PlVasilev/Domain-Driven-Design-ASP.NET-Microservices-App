using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seller.Listings.Application.Listings.Listings.Commands.Create;
using Seller.Listings.Application.Listings.Listings.Commands.Deal;
using Seller.Listings.Application.Listings.Listings.Commands.Delete;
using Seller.Listings.Application.Listings.Listings.Commands.Edit;
using Seller.Listings.Application.Listings.Listings.Queries.All;
using Seller.Listings.Application.Listings.Listings.Queries.Common;
using Seller.Listings.Application.Listings.Listings.Queries.Details;
using Seller.Listings.Application.Listings.Listings.Queries.Mine;
using Seller.Listings.Application.Listings.Listings.Queries.TitleAndSellerName;

namespace Seller.Listings.Web.Listings
{
    [Authorize]
    public class ListingController : ApiController
    {
        [HttpGet]
        [Route(nameof(All))]
        public async Task<ActionResult<IReadOnlyCollection<AllListingResponseModel>>> All([FromRoute] AllListingQuery query) => 
        await this.Send(query);

        [HttpGet]
        [Route(nameof(Mine))]
        public async Task<ActionResult<IReadOnlyCollection<AllListingResponseModel>>> Mine([FromRoute] MineListingQuery query) =>
            await this.Send(query);

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DetailsListingResponseModel>> Details([FromRoute] DetailsListingQuery query) =>
            await this.Send(query);

        [HttpGet]
        [Route("GetTitleAndSellerName/{id}")]
        public async Task<ActionResult<TitleAndSellerNameListingResponseModel>> GetTitleAndSellerName(
            [FromRoute] TitleAndSellerNameListingQuery query)
            => await this.Send(query);

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<ActionResult<bool>> Update(EditListingCommand command) => await Send(command);
  
        
        [HttpPut]
        [Route(nameof(Deal))]
        public async Task<ActionResult<bool>> Deal(DealListingCommand command) => await this.Send(command);

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<bool>> Delete([FromRoute] DeleteListingCommand command) => await Send(command);
        
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<ListingCreateResponseModel>> Create(CreateListingCommand command)
            => await this.Send(command);

        // private string UserId() => sellerService.GetIdByUser(currentUser.UserId).Result.Id;
    }
}
