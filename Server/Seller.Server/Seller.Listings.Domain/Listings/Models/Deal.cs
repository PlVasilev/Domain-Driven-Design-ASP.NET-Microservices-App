using System;
using Seller.Listings.Domain.Listings.Exceptions;
using Seller.Shared.DDD.Domain;
using Seller.Shared.DDD.Domain.Models;
using static Seller.Shared.DDD.Domain.Models.ModelConstants.Common;
using static Seller.Shared.DDD.Domain.Models.ModelConstants.Listing;

namespace Seller.Listings.Domain.Listings.Models
{
    public class Deal : Entity<string>, IAggregateRoot
    {
        internal Deal(string title, string buyerId, string listingId, decimal price, string sellerId)
        {

            Validate(title, price,sellerId,buyerId,listingId);

            Title = title;
            BuyerId = buyerId;
            CreatedOn = DateTime.UtcNow;
            IsDeleted = false;
            ListingId = ListingId;
            Price = price;
            SellerId = sellerId;
        }

        private Deal()
        {
            Title = default!;
            Buyer = default!;
            CreatedOn = default!;
            IsDeleted = false;
            Listing = default!;
            Price = default!;
            Seller = default!;
            ListingId = default!;
            SellerId = default!;
            BuyerId = default!;
        }

        public string Title { get; private set; }

        public decimal Price { get; private set; }

        public string ListingId { get; private set; }
        public Listing? Listing { get; private set; }

        public string SellerId { get; private set; }
        public UserSeller? Seller { get; private set; }

        public string BuyerId { get; private set; }
        public UserSeller? Buyer { get; private set; }
        
        public bool IsDeleted { get; private set; }

        public DateTime CreatedOn { get; private set; }

        private void Validate(string title,decimal price,string sellerId, string buyerId, string listingId)
        {
            ValidateTitle(title);
            ValidatePrice(price);
            ValidateSellerId(sellerId);
            ValidateBuyerId(buyerId);
            ValidateListingId(listingId);
        }

        private void ValidateTitle(string title)
            => Guard.ForStringLength<InvalidDealException>(
                title,
                MinTitleLength,
                MaxTitleLength,
                nameof(this.Title));

        private void ValidatePrice(decimal price)
            => Guard.AgainstOutOfRange<InvalidDealException>(
                price,
                Zero,
                decimal.MaxValue,
                nameof(this.Price));

        private void ValidateSellerId(string sellerId)
            => Guard.ForStringLength<InvalidUserSellerException>(
                sellerId,
                MinGuidIdLength,
                MaxGuidIdLength,
                nameof(this.SellerId));

        private void ValidateBuyerId(string buyerId)
            => Guard.ForStringLength<InvalidUserSellerException>(
                buyerId,
                MinGuidIdLength,
                MaxGuidIdLength,
                nameof(this.BuyerId));

        private void ValidateListingId(string listingId)
            => Guard.ForStringLength<InvalidUserSellerException>(
                listingId,
                MinGuidIdLength,
                MaxGuidIdLength,
                nameof(this.ListingId));
    }
}
