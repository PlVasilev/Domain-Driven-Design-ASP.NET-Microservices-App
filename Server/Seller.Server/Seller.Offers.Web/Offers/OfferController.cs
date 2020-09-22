using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seller.Offers.Application.Offers.Commands.Add;

namespace Seller.Offers.Web.Offers
{
    // using Application.Common;
    // using Application.Dealerships.CarAds.Commands.ChangeAvailability;
    // using Application.Dealerships.CarAds.Commands.Create;
    // using Application.Dealerships.CarAds.Commands.Delete;
    // using Application.Dealerships.CarAds.Commands.Edit;
    // using Application.Dealerships.CarAds.Queries.Categories;
    // using Application.Dealerships.CarAds.Queries.Details;
    // using Application.Dealerships.CarAds.Queries.Mine;
    // using Application.Dealerships.CarAds.Queries.Search;

    public class OfferController : ApiController
    {
        [HttpPost]
        [Authorize]
        [Route(nameof(Add))]
        public async Task<ActionResult<AddOfferOutputModel>> Add(
            AddOfferCommand command)
            => await this.Send(command);
        //[HttpGet]
        //public async Task<ActionResult<SearchCarAdsOutputModel>> Search(
        //    [FromQuery] SearchCarAdsQuery query)
        //    => await this.Send(query);

        //[HttpGet]
        //[Route(Id)]
        //public async Task<ActionResult<CarAdDetailsOutputModel>> Details(
        //    [FromRoute] CarAdDetailsQuery query)
        //    => await this.Send(query);

        //[HttpPost]
        //[Authorize]
        //public async Task<ActionResult<CreateCarAdOutputModel>> Create(
        //    CreateCarAdCommand command)
        //    => await this.Send(command);

        //[HttpPut]
        //[Authorize]
        //[Route(Id)]
        //public async Task<ActionResult> Edit(
        //    int id, EditCarAdCommand command)
        //    => await this.Send(command.SetId(id));

        //[HttpDelete]
        //[Authorize]
        //[Route(Id)]
        //public async Task<ActionResult> Delete(
        //    [FromRoute] DeleteCarAdCommand command)
        //    => await this.Send(command);

        //[HttpGet]
        //[Authorize]
        //[Route(nameof(Mine))]
        //public async Task<ActionResult<MineCarAdsOutputModel>> Mine(
        //    [FromQuery] MineCarAdsQuery query)
        //    => await this.Send(query);

        //[HttpGet]
        //[Route(nameof(Categories))]
        //public async Task<ActionResult<IEnumerable<GetCarAdCategoryOutputModel>>> Categories(
        //    [FromQuery] GetCarAdCategoriesQuery query)
        //    => await this.Send(query);

        //[HttpPut]
        //[Authorize]
        //[Route(Id + PathSeparator + nameof(ChangeAvailability))]
        //public async Task<ActionResult> ChangeAvailability(
        //    [FromRoute] ChangeAvailabilityCommand query)
        //    => await this.Send(query);
    }
}
