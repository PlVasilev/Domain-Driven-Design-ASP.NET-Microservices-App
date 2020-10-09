using System;
using Seller.Listings.Domain.Sales.Models;
using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Sales.Deals.Commands.Common
{
    
    public abstract class DealCommand<TCommand> : EntityCommand<string>
        where TCommand : EntityCommand<string>
    {
        public string Title { get; set; } = default!;

        public decimal Price { get;  set; }

        public string OfferId { get; set; } = default!;

        public string ListingId { get;  set; } = default!;
        public Listing? Listing { get;  set; }

        public string SellerId { get;  set; } = default!;
        public UserSeller? Seller { get;  set; }

        public string BuyerId { get;  set; } = default!;
        public UserSeller? Buyer { get;  set; }
        
        public bool IsDeleted { get;  set; }

        public DateTime CreatedOn { get;  set; }
        
    }
}
