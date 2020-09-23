using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seller.Offers.Application.Offers.Commands.Accept;
using Seller.Offers.Application.Offers.Commands.Add;
using Seller.Offers.Application.Offers.Commands.Delete;
using Seller.Offers.Application.Offers.Queries.All;
using Seller.Offers.Application.Offers.Queries.Current;
using Seller.Offers.Application.Offers.Queries.GetCurrentOfferCount;
using Seller.Offers.Application.Offers.Queries.Mine;

namespace Seller.Offers.Web.Offers
{
    public class OfferController : ApiController
    {
        [HttpPost]
        [Authorize]
        [Route(nameof(Add))]
        public async Task<ActionResult<AddOfferOutputModel>> Add(
            AddOfferCommand command)
            => await this.Send(command);

        [HttpPost]
        [Authorize]
        [Route(nameof(GetCurrentOffer))]
        public async Task<ActionResult<decimal>> GetCurrentOffer(CurrentOfferQuery query) =>
                await this.Send(query);

        [HttpGet]
        [Authorize]
        [Route("count/{id}")]
        public async Task<ActionResult<int>> Count([FromRoute] CurrentOfferCountQuery query) =>
                await this.Send(query);

        [HttpGet]
        [Authorize]
        [Route("Mine/{id}")]
        public async Task<ActionResult<IReadOnlyCollection<MineOfferOutputModel>>> Mine([FromRoute] MineOfferQuery query) =>
          await this.Send(query);

        [HttpGet]
        [Authorize]
        [Route("All/{id}")]
        public async Task<ActionResult<IReadOnlyCollection<AllOfferOutputModel>>> All([FromRoute] AllOfferQuery query) =>
            await this.Send(query);

        [HttpDelete]
        [Authorize]
        [Route("DeleteOffer/{id}")]
        public async Task<ActionResult> DeleteOffer([FromRoute] DeleteOfferCommand command) =>
            await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(nameof(Accept))]
        public async Task<ActionResult<bool>> Accept(AcceptOfferCommand command) =>
            await this.Send(command);


    }
}
