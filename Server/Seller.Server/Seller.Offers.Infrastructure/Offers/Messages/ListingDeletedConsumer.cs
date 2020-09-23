using System.Threading.Tasks;
using MassTransit;
using Seller.Listing.Gateway.Services.Offer;
using Seller.Offers.Application.Offers;
using Seller.Shared.Messages.Offers;

namespace Seller.Offers.Infrastructure.Offers.Messages
{
    public class ListingDeletedConsumer : IConsumer<ListingDeletedMessage>
    {
        private readonly IOfferRepository offerRepository;


        public ListingDeletedConsumer(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public async Task Consume(ConsumeContext<ListingDeletedMessage> context)
        {
            var message = context.Message.ListingId;
            await offerRepository.Delete(message);
        }
    }
}
