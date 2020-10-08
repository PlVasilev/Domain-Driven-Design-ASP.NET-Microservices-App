using System;

namespace Seller.Listings.Application.Sales.Listings.Commands.Create
{
    public class ListingCreateResponseModel
    {
        public ListingCreateResponseModel()
        {
            
        }
        public ListingCreateResponseModel(string id, string title, string imageUrl, string description, decimal price, DateTime created, string sellerId, bool isDeleted)
        {
            Id = id;
            Title = title;
            ImageUrl = imageUrl;
            Description = description;
            Price = price;
            Created = created;
            SellerId = sellerId;
            IsDeleted = isDeleted;
        }

        public string? Id { get; }

        public string? Title { get;}

        public string? ImageUrl { get; }
        public string? Description { get; }

        public decimal Price { get;  }

        public DateTime Created { get; }

        public string? SellerId { get; }

        public bool IsDeleted { get;  }

    }
}
