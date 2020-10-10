using Seller.Listings.Domain.Listings.Models;

namespace Seller.Listings.Domain.Listings.Factories
{
    public class ListingFactory : IListingFactory
    {
        private string title = default!;
        private string imageUrl = default!;
        private string description = default!;
        private decimal price = default;
        private string sellerId = default!;

        public IListingFactory WithTitle(string title)
        {
            this.title = title;
            return this;
        }

        public IListingFactory WithImageUrl(string imageUrl)
        {
            this.imageUrl = imageUrl;
            return this;
        }

        public IListingFactory WithDescription(string description)
        {
            this.description = description;
            return this;
        }

        public IListingFactory WithPrice(decimal price)
        {
            this.price = price;
            return this;
        }

        public IListingFactory WithSellerId(string sellerId)
        {
            this.sellerId = sellerId;
            return this;
        }

        public Listing Build()
        {
            return new Listing(
                this.title,
                this.description,
                this.imageUrl,
                this.price,
                this.sellerId);
        }
    }
}
