using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Seller.Offers.Features.Offer.Services.Interfaces;
using Seller.Shared.Messages.Offers;

namespace Seller.Offers.Messages
{
    using Features.Offer.Services.Interfaces;

    public class ListingAcceptedConsumer : IConsumer<ListingAcceptedMessage>
    {
        private readonly IOfferService offerService;


        public ListingAcceptedConsumer(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        public async Task Consume(ConsumeContext<ListingAcceptedMessage> context)
        {
            var message = context.Message.ListingId;
            await offerService.Accept(message);
        }
    }
}
