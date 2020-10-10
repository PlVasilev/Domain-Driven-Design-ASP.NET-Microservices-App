using System;

namespace Seller.Listings.Application.Listings.Listings.Queries.Details
{
    public class DetailsListingResponseModel
    {
        public DetailsListingResponseModel()
        {
            
        }

        public DetailsListingResponseModel(
            string id,string title, string imageUrl, decimal price, string description, string sellerId, string firstName, string lastName, DateTime created)
        {
            Id = id;
            Title = title;
            ImageUrl = imageUrl;
            Price = price;
            Description = description;
            OffersCount = 0;
            SellerId = sellerId;
            SellerName = firstName + " " + lastName;
            Created = created.ToString("D");
        }
        public string? Id { get; }
        public string? Title { get; }
        public string? ImageUrl { get; }
        public decimal Price { get;  }
        public string? Description { get;  }
        public string? Created { get; }
        public int OffersCount { get; }
        public string? SellerId { get;  }
        public string? SellerName { get;  }
    }
}
