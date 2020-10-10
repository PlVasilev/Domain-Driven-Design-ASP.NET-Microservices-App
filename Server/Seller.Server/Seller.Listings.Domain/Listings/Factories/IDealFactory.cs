using Seller.Listings.Domain.Listings.Models;
using Seller.Shared.DDD.Domain;

namespace Seller.Listings.Domain.Listings.Factories
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
