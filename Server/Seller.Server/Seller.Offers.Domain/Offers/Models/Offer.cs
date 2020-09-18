using System;
using Seller.Offers.Domain.Offers.Exceptions;
using Seller.Shared.DDD.Domain;
using Seller.Shared.DDD.Domain.Models;

namespace Seller.Offers.Domain.Offers.Models
{
    using static Shared.DDD.Domain.Models.ModelConstants.Common;
    using static Shared.DDD.Domain.Models.ModelConstants.Offer;

    public class Offer : Entity<string>, IAggregateRoot
    {
        internal Offer(
            string listingId,
            string title,
            decimal price,
            string creatorId,
            string creatorName
     )
        {
            Validate(creatorId, title, price, listingId, creatorName);

            CreatorId = creatorId;
            Created = DateTime.UtcNow;
            Price = price;
            ListingId = listingId;
            IsAccepted = false;
            IsDeleted = false;
            Title = title;
            CreatorName = creatorName;
        }

        private Offer()
        {
            CreatorId = default!;
            Created = default;
            Price = default;
            ListingId = default!;
            IsAccepted = default;
            IsDeleted = default;
            Title = default!;
            CreatorName = default!;

        }

        public string ListingId { get; private set; }

        public string Title { get; private set; }

        public decimal Price { get; private set; }

        public DateTime Created { get; private set; }

        public string CreatorId { get; private set; }

        public string CreatorName { get; private set; }

        public bool IsAccepted { get; private set; }

        public bool IsDeleted { get; private set; }

        public Offer UpdatePrice(decimal price)
        {
            this.ValidatePrice(price);
            this.Price = price;
            return this;
        }

        public Offer UpdateIsAccepted(bool isAccepted)
        {
            this.IsAccepted = true;
            return this;
        }

        public Offer UpdateIsDeleted(decimal isDeleted)
        {
            this.IsDeleted = true;
            return this;
        }

        private void Validate(string creatorId,string title,decimal price,string listingId, string creatorName)
        {
            this.ValidateCreatorId(creatorId);
            this.ValidateTitle(title);
            this.ValidatePrice(price);
            this.ValidateListingId(listingId);
            this.ValidateName(creatorName);
        }

        private void ValidateCreatorId(string creatorId)
            => Guard.ForStringLength<InvalidOfferException>(
                creatorId,
                MinGuidIdLength,
                MaxGuidIdLength,
                nameof(this.CreatorId));

        private void ValidateTitle(string title)
            => Guard.ForStringLength<InvalidOfferException>(
                title,
                MinTitleLength,
                MaxTitleLength,
                nameof(this.Title));


        private void ValidatePrice(decimal price)
            => Guard.AgainstOutOfRange<InvalidOfferException>(
                price,
                Zero,
                decimal.MaxValue,
                nameof(this.Price));

        private void ValidateListingId(string listingId)
            => Guard.ForStringLength<InvalidOfferException>(
                listingId,
                MinGuidIdLength,
                MaxGuidIdLength,
                nameof(this.ListingId));

        private void ValidateName(string creatorName)
            => Guard.ForStringLength<InvalidOfferException>(
                creatorName,
                MinCreatorNameLength,
                MaxCreatorNameLength,
                nameof(this.CreatorName));
    }
}
