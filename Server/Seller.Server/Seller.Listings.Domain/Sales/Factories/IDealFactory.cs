using System;
using System.Collections.Generic;
using System.Text;
using Seller.Listings.Domain.Sales.Models;
using Seller.Shared.DDD.Domain;

namespace Seller.Listings.Domain.Sales.Factories
{
    public interface IDealFactory : IFactory<Deal>
    {
        IDealFactory WithTitle(string title);
        IDealFactory WithBuyerId(string imageUrl);
        IDealFactory WithListingId(string description);
        IDealFactory WithPrice(decimal price);
        IDealFactory WithSellerId(string sellerId);
    }
}
