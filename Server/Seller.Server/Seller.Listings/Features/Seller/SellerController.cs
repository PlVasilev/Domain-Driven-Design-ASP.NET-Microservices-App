using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seller.Listings.Features.Seller.Models;
using Seller.Listings.Features.Seller.Services.Interfaces;
using Seller.Listings.Features.Seller.Services.Models;
using Seller.Shared.Controllers;
using Seller.Shared.Services.Identity;

namespace Seller.Listings.Features.Seller
{
    [Authorize]
    public class SellerController : ApiController
    {
        private readonly ISellerService sellerService;
        private readonly ICurrentUserService currentUser;

        public SellerController(ISellerService sellerService, ICurrentUserService currentUser)
        {
            this.sellerService = sellerService;
            this.currentUser = currentUser;
        }

        [HttpGet]
        [Route("Id")]
        public async Task<ActionResult<SellerIdResponseModel>> GetSellerId() => await sellerService.GetIdByUser(currentUser.UserId);



        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create(RegisterSellerRequestModel model)
        {
            var result = 
                await sellerService.CreateUserSeller(model.UserName, model.FirstName, model.LastName, model.Email, model.PhoneNumber, currentUser.UserId);

            if (result) return Ok();

            return BadRequest();
        }

    }
}
