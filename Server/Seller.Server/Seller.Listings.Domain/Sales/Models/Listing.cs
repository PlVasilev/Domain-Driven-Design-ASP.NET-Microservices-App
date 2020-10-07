namespace Seller.Listings.Domain.Sales.Models
{
    using System;
    using Exceptions;
    using Seller.Shared.DDD.Domain;
    using Seller.Shared.DDD.Domain.Models;
    using static Seller.Shared.DDD.Domain.Models.ModelConstants.Common;
    using static Seller.Shared.DDD.Domain.Models.ModelConstants.Listing;
    public class Listing : Entity<string>, IAggregateRoot
    {

        internal Listing(string title, string description, string imageUrl, decimal price, UserSeller seller)
        {
            Validate(title, description, imageUrl, price);

            Title = title;
            Created = DateTime.UtcNow;
            ImageUrl = imageUrl;
            Description = description;
            Price = price;
            Seller = seller;
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
            Seller = default!;
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

        public UserSeller Seller { get; private set; }

        public bool IsDeleted { get; private set; }

        public bool IsDeal { get; private set; }

        private void Validate(string title, string description, string imageUrl, decimal price)
        {
            ValidateTitle(title);
            ValidateDescription(description);
            ValidateImageUrl(imageUrl);
            ValidatePrice(price);
       
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

    }
}
