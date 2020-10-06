using Seller.Listings.Domain.Sales.Models;

namespace Seller.Listings.Domain.Sales.Factories
{
    public class DealFactory : IDealFactory
    {

        private string title = default!;
        private string buyerId = default!;
        private string listingId = default!;
        private decimal price = default;
        private string sellerId = default!;

        public IDealFactory WithTitle(string title)
        {
            this.title = title;
            return this;
        }

        public IDealFactory WithBuyerId(string buyerId)
        {
            this.buyerId = buyerId;
            return this;
        }

        public IDealFactory WithListingId(string listingId)
        {
            this.listingId = listingId;
            return this;
        }

        public IDealFactory WithPrice(decimal price)
        {
            this.price = price;
            return this;
        }

        public IDealFactory WithSellerId(string sellerId)
        {
            this.sellerId = sellerId;
            return this;
        }

        public Deal Build()
        {
            return new Deal(
                this.title,
                this.buyerId,
                this.listingId,
                this.price,
                this.sellerId);
        }
    }
}
