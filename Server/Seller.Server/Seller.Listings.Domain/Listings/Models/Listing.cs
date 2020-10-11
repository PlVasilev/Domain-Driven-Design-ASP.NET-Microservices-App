using System;
using Seller.Listings.Domain.Listings.Exceptions;
using Seller.Shared.DDD.Domain;
using Seller.Shared.DDD.Domain.Models;

namespace Seller.Listings.Domain.Listings.Models
{
    using static Shared.DDD.Domain.Models.ModelConstants.Common;
    using static Shared.DDD.Domain.Models.ModelConstants.Listing;
    public class Listing : Entity<string>, IAggregateRoot
    {

        internal Listing(string title, string description, string imageUrl, decimal price, string sellerId)
        {
            Validate(title, description, imageUrl, price, sellerId);

            Title = title;
            Created = DateTime.UtcNow;
            ImageUrl = imageUrl;
            Description = description;
            Price = price;
            SellerId = sellerId;
            Seller = default!;
            IsDeal = false;
            IsDeleted = false;

        }

        private Listing()
        {
            Title = default!;
            Created = default;
            ImageUrl = default!;
            Description = default!;
            Price = default;
            SellerId = default!;
            Seller = default!;
            IsDeal = default!;
            IsDeleted = false;
        }



        public string Title { get; private set; }

        public string ImageUrl { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public DateTime Created { get; private set; }

        public Deal Deal { get; private set; } = default!;

        public string SellerId { get; private set; }
        public UserSeller Seller { get; private set; }

        public bool IsDeleted { get; private set; }

        public bool IsDeal { get; private set; }

        public Listing UpdateTitle(string title)
        {
            this.ValidateTitle(title);
            this.Title = title;
            return this;
        }

        public Listing UpdateDescription(string description)
        {
            this.ValidateDescription(description);
            this.Description = description;
            return this;
        }

        public Listing UpdateImageUrl(string imageUrl)
        {
            this.ValidateImageUrl(imageUrl);
            this.ImageUrl = imageUrl;
            return this;
        }

        public Listing UpdateImageUrl(decimal price)
        {
            this.ValidatePrice(price);
            this.Price = price;
            return this;
        }

        public Listing UpdatePrice(decimal price)
        {
            this.ValidatePrice(price);
            this.Price = price;
            return this;
        }

        public Listing UpdateCreated()
        {
            this.Created = DateTime.UtcNow;
            return this;
        }

        public Listing UpdateIsDeleted()
        {
            this.IsDeleted = true;
            return this;
        }

        public Listing UpdateIsDeal()
        {
            this.IsDeal = true;
            return this;
        }

        private void Validate(string title, string description, string imageUrl, decimal price, string sellerId)
        {
            ValidateTitle(title);
            ValidateDescription(description);
            ValidateImageUrl(imageUrl);
            ValidatePrice(price);
            ValidateSellerId(sellerId);
        }

        private void ValidateTitle(string title)
            => Guard.ForStringLength<InvalidListingException>(
                title,
                MinTitleLength,
                MaxTitleLength,
                nameof(this.Title));

        private void ValidatePrice(decimal price)
            => Guard.AgainstOutOfRange<InvalidListingException>(
                price,
                Zero,
                decimal.MaxValue,
                nameof(this.Price));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidListingException>(
                imageUrl,
                nameof(this.ImageUrl));

        private void ValidateDescription(string description)
            => Guard.ForStringLength<InvalidListingException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));

        private void ValidateSellerId(string sellerId)
            => Guard.ForStringLength<InvalidUserSellerException>(
                sellerId,
                MinGuidIdLength,
                MaxGuidIdLength,
                nameof(this.SellerId));

    }
}
