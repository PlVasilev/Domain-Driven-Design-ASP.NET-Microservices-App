using Seller.Shared.DDD.Application;

namespace Seller.Offers.Application.Offers.Commands.Common
{
    
    public abstract class OfferCommand<TCommand> : EntityCommand<string>
        where TCommand : EntityCommand<string>
    {

        public decimal Price { get; set; } 

        public string CreatorId { get; set; } = default!;

        public string ListingId { get; set; } = default!;

        public string Title { get; set; } = default!;

        public string CreatorName { get; set; } = default!;
    }
}
