using System.Threading.Tasks;
using MassTransit;
using Seller.Listing.Gateway.Services.Offer;
using Seller.Offers.Application.Offers;
using Seller.Shared.Messages.Offers;

namespace Seller.Offers.Infrastructure.Offers.Messages
{
    public class ListingEditedConsumer : IConsumer<ListingEditedMessage>
    {
        private readonly IOfferRepository offerRepository;


        public ListingEditedConsumer(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public async Task Consume(ConsumeContext<ListingEditedMessage> context)
        {
            var message = context.Message;
            await offerRepository.Edit(message.ListingId, message.Title);
        }
    }
   
}
