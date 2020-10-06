using System;
using Seller.Listings.Domain.Sales.Exceptions;
using Seller.Shared.DDD.Domain;
using Seller.Shared.DDD.Domain.Models;
using static Seller.Shared.DDD.Domain.Models.ModelConstants.Common;
using static Seller.Shared.DDD.Domain.Models.ModelConstants.Listing;

namespace Seller.Listings.Domain.Sales.Models
{
    public class Deal : Entity<string>, IAggregateRoot
    {
        internal Deal(string title, string buyerId,string listingId, decimal price, string sellerId)
        {

            Validate(title, buyerId, listingId, price, sellerId);

            Title = title;
            BuyerId = buyerId;
            CreatedOn = DateTime.UtcNow;
            IsDeleted = false;
            ListingId = listingId;
            Price = price;
            SellerId = sellerId;
        }

  

        private Deal()
        {
            Title = default!;
            BuyerId = default!;
            CreatedOn = default!;
            IsDeleted = false;
            ListingId = default!;
            Price = default!;
            SellerId = default!;
        }

      

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string ListingId { get; set; }
        
        public string SellerId { get; set; }
        
        public string BuyerId { get; set; }
        
        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        private void Validate(string title, string buyerId, string listingId, decimal price, string sellerId)
        {
            ValidateTitle(title);
            ValidateBuyerId(buyerId);
            ValidateListingId(listingId);
            ValidatePrice(price);
            ValidateSellerId(sellerId);

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


        private void ValidateSellerId(string buyerId)
            => Guard.ForStringLength<InvalidDealException>(
                buyerId,
                MinGuidIdLength,
                MaxGuidIdLength,
                nameof(this.BuyerId));

        private void ValidateBuyerId(string sellerId)
            => Guard.ForStringLength<InvalidDealException>(
                sellerId,
                MinGuidIdLength,
                MaxGuidIdLength,
                nameof(this.SellerId));

        private void ValidateListingId(string listingId)
            => Guard.ForStringLength<InvalidDealException>(
                listingId,
                MinGuidIdLength,
                MaxGuidIdLength,
                nameof(this.ListingId));


    }
}
