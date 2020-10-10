using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Seller.Listings.Application.Listings.Deals.Commands.Common;
using Seller.Listings.Application.Listings.Listings;
using Seller.Listings.Domain.Listings.Factories;
using Seller.Shared.Messages.Offers;

namespace Seller.Listings.Application.Listings.Deals.Commands.Create
{
    public class CreateDealCommand : DealCommand<CreateDealCommand>, IRequest<bool>
    {
        public class CreateListingCommandHandler : IRequestHandler<CreateDealCommand, bool>
        {
            private readonly IDealRepository dealRepository;
            private readonly IListingRepository listingRepository;
            private readonly IDealFactory dealFactory;
            private readonly IBus publisher;

            public CreateListingCommandHandler(
                IDealRepository dealRepository,
                IDealFactory dealFactory,
                IListingRepository listingRepository,
            IBus publisher)
            {
                this.listingRepository = listingRepository;
                this.dealRepository = dealRepository;
                this.dealFactory = dealFactory;
                this.publisher = publisher;
            }

            public async Task<bool> Handle(
                CreateDealCommand request,
                CancellationToken cancellationToken)
            {
                var deal = dealFactory
                    .WithTitle(request.Title)
                    .WithPrice(request.Price)
                    .WithListingId(request.ListingId)
                    .WithBuyerId(request.BuyerId)
                    .WithSellerId(request.SellerId)
                    .Build();


                var listing = await this.listingRepository.GetOnlyById(request.ListingId, cancellationToken);
                listing.UpdateIsDeal();

                await dealRepository.Save(deal, cancellationToken);
                await listingRepository.Save(listing, cancellationToken);

                if (deal.Id == null)
                {
                    return false;
                }

                await this.publisher.Publish(new ListingAcceptedMessage
                {
                    ListingId = request.OfferId
                }, cancellationToken);

                return true;
            }
        }
    }
}
