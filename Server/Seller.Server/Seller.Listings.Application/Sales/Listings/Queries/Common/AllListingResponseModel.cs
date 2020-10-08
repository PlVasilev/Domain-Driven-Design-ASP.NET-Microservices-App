﻿using System;

namespace Seller.Listings.Application.Sales.Listings.Queries.Common
{
    public class AllListingResponseModel
    {
        public AllListingResponseModel()
        {
            
        }

        public AllListingResponseModel(string id, string title, string imageUrl, decimal price, DateTime created)
        {
            Id = id;
            Title = title;
            ImageUrl = imageUrl;
            Price = price;
            Created = created.ToString("g");
        }

        public string? Id { get; }

        public string? Title { get; }
      
        public string? ImageUrl { get; }

        public decimal Price { get; }

        public string? Created { get;  }
    }
}
