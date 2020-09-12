using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refit;
using Seller.Listing.Gateway.Models.Offers;

namespace Seller.Listing.Gateway.Services.Offer
{
    public interface IOfferService
    {
        [Get("/Offer/All/{id}")]
        Task<List<OfferResponceModel>> All(string id);

        [Put("/Offer/Accept")]
        Task<bool> Accept(string id);
    }
}
