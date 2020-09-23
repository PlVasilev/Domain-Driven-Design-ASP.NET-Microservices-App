using System.Threading.Tasks;
using MassTransit;
using Seller.Offers.Application.Offers;
using Seller.Shared.Messages.Offers;

namespace Seller.Offers.Infrastructure.Offers.Messages
{
    public class ListingAcceptedConsumer : IConsumer<ListingAcceptedMessage>
    {
        private readonly IOfferRepository offerRepository;


        public ListingAcceptedConsumer(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public async Task Consume(ConsumeContext<ListingAcceptedMessage> context)
        {
            var message = context.Message.ListingId;
            await offerRepository.Accept(message);
        }
    }
}
