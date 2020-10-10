using System;

namespace Seller.Listings.Application.Listings.Deals.Queries.Common
{
    public class DealResponseModel
    {
        public DealResponseModel()
        {
            
        }

        public DealResponseModel(string id, string title, decimal price, DateTime createdOn)
        {
            Id = id;
            Title = title;
            Price = price;
            CreatedOn = createdOn.ToString("g");
        }

        public string? Id { get; }
        public string? Title { get;}
        public decimal? Price { get;  }
        public string? CreatedOn { get; }
    }
}
