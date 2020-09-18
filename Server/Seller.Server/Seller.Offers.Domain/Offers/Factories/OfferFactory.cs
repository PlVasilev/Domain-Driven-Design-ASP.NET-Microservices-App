using Seller.Offers.Domain.Offers.Models;

namespace Seller.Offers.Domain.Offers.Factories
{
    internal class OfferFactory : IOfferFactory
    {
        private string creatorId = default!;
        private decimal price = default!;
        private string listingId = default!;
        private string title = default!;
        private string creatorName = default!;


        public Offer Build()
        {
            return new Offer(
                this.listingId,
                this.title,
                this.price,
                this.creatorId,
                this.creatorName
            );
        }

        public IOfferFactory WithCreatorId(string creatorId)
        {
            this.creatorId = creatorId;
            return this;
        }

        public IOfferFactory WithTitle(string title)
        {
            this.title = title;
            return this;
        }

        public IOfferFactory WithPrice(decimal price)
        {
            this.price = price;
            return this;
        }

        public IOfferFactory WithListingId(string listingId)
        {
            this.listingId = listingId;
            return this;
        }

        public IOfferFactory WithCreatorName(string creatorName)
        {
            this.creatorName = creatorName;
            return this;
        }
    }
}
