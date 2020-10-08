using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Seller.Listings.Application.Sales.Listings.Commands.Common;
using Seller.Listings.Domain.Sales.Factories;
using Seller.Shared.Messages.Offers;

namespace Seller.Listings.Application.Sales.Listings.Commands.Create
{
    public class CreateListingCommand : ListingCommand<CreateListingCommand>, IRequest<ListingCreateResponseModel>
    {
        public class CreateListingCommandHandler : IRequestHandler<CreateListingCommand, ListingCreateResponseModel>
        {
            private readonly IListingRepository listingRepository;
            private readonly IListingFactory listingFactory;
            private readonly IBus publisher;

            public CreateListingCommandHandler(
                IListingRepository listingRepository,
                IListingFactory listingFactory,
                IBus publisher)
            {
                this.listingRepository = listingRepository;
                this.listingFactory = listingFactory;
                this.publisher = publisher;
            }

            public async Task<ListingCreateResponseModel> Handle(
                CreateListingCommand request,
                CancellationToken cancellationToken)
            {
                var listing = listingFactory
                    .WithTitle(request.Title)
                    .WithImageUrl(request.ImageUrl)
                    .WithDescription(request.Description)
                    .WithPrice(request.Price)
                    .WithSellerId(request.SellerId)
                    .Build();

                await this.listingRepository.Save(listing, cancellationToken);
                if (listing.Id != null)
                {

                    await this.publisher.Publish(new ListingCreatedMessage
                    {
                        Title = listing.Title,
                        Price = listing.Price
                    }, cancellationToken);

                    return new ListingCreateResponseModel(listing.Id, listing.Title, listing.ImageUrl,
                        listing.Description, listing.Price, listing.Created, listing.SellerId, listing.IsDeleted);

                }
                return new ListingCreateResponseModel();
            }
        }
    }
}
