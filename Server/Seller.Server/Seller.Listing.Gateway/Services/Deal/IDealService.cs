using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using Seller.Listing.Gateway.Models.Deals;

namespace Seller.Listing.Gateway.Services.Deal
{
    public interface IDealService
    {
        [Post("/Deal/Create")]
        Task<bool> Create(DealCreateRequestModel model);

        [Get("/Deal/BuyDeals/{id}")]
        Task<List<DealResponseModel>> BuyDeals(string id);

        [Get("/Deal/SaleDeals/{id}")]
        Task<List<DealResponseModel>> SaleDeals(string id);
    }
}
