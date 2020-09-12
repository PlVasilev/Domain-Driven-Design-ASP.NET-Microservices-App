using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Seller.Offers.Features.Offer.Services.Interfaces;
using Seller.Shared.Messages.Offers;

namespace Seller.Offers.Messages
{
    public class ListingEditedConsumer : IConsumer<ListingEditedMessage>
    {
        private readonly IOfferService offerService;


        public ListingEditedConsumer(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        public async Task Consume(ConsumeContext<ListingEditedMessage> context)
        {
            var message = context.Message;
            await offerService.Edit(message.ListingId, message.Title);
        }
    }
   
}
