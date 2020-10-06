using System;
using System.Collections.Generic;
using System.Text;
using Seller.Listings.Domain.Sales.Models;
using Seller.Shared.DDD.Domain;

namespace Seller.Listings.Domain.Sales.Factories
{
    public interface IListingFactory : IFactory<Listing>
    {
        IListingFactory WithTitle(string title);

        IListingFactory WithImageUrl(string imageUrl);
        IListingFactory WithDescription(string description);

        IListingFactory WithPrice(decimal price);

        IListingFactory WithSellerId(string sellerId);

    }
}
