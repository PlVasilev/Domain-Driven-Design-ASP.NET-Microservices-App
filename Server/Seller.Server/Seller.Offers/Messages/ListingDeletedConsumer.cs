using System.Threading.Tasks;
using MassTransit;
using Seller.Offers.Features.Offer.Services.Interfaces;
using Seller.Shared.Messages.Offers;

namespace Seller.Offers.Messages
{
    public class ListingDeletedConsumer : IConsumer<ListingDeletedMessage>
    {
        private readonly IOfferService offerService;


        public ListingDeletedConsumer(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        public async Task Consume(ConsumeContext<ListingDeletedMessage> context)
        {
            var message = context.Message.ListingId;
            await offerService.Delete(message);
        }
    }
}
