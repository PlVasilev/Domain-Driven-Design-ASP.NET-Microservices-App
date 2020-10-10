using Seller.Listings.Domain.Listings.Models;
using Seller.Shared.DDD.Domain;

namespace Seller.Listings.Domain.Listings.Factories
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
