using System;

namespace Seller.Offers.Application.Offers.Queries.All
{
    public class AllOfferOutputModel
    {
        public AllOfferOutputModel(string id, string listingId, decimal price, DateTime created, string creatorId, bool isAccepted, string title, string creatorName)
        {
            Id = id;
            ListingId = listingId;
            Price = price;
            Created = created.ToString("g");
            CreatorId = creatorId;
            IsAccepted = isAccepted;
            Title = title;
            CreatorName = creatorName;
        }
        
        public string Id { get; }
        public string ListingId { get; }
        public decimal Price { get;  }
        public string Created { get; }
        public string CreatorId { get;  }
        public bool IsAccepted { get;  }
        public string Title { get;  }
        public string CreatorName { get;  }
    }
}
