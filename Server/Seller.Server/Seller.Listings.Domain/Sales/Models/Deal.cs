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
        internal Deal(string title, UserSeller buyer,Listing listing, decimal price, UserSeller seller)
        {

            Validate(title, price);

            Title = title;
            Buyer = buyer;
            CreatedOn = DateTime.UtcNow;
            IsDeleted = false;
            Listing = listing;
            Price = price;
            Seller = seller;
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
        }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public Listing Listing { get; set; }
        
        public UserSeller Seller { get; set; }
        
        public UserSeller Buyer { get; set; }
        
        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        private void Validate(string title,decimal price)
        {
            ValidateTitle(title);
            ValidatePrice(price);
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
    }
}
