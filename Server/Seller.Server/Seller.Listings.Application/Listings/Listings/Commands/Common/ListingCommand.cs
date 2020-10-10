using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Listings.Listings.Commands.Common
{
    
    public abstract class ListingCommand<TCommand> : EntityCommand<string>
        where TCommand : EntityCommand<string>
    {
        public string Title { get; set; } = default!;
      
        public string ImageUrl { get; set; } = default!;

        public string Description { get; set; } = default!;

        public decimal Price { get; set; }

        public bool IsDeleted { get; set; } = false;
        public string SellerId { get; set; } = default!;
        
    }
}
