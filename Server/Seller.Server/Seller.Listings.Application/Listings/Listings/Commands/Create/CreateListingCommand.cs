using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Seller.Listings.Application.Listings.Listings.Commands.Common;
using Seller.Listings.Application.Listings.UserSellers;
using Seller.Listings.Domain.Listings.Factories;
using Seller.Shared.Messages.Offers;
using Seller.Shared.Services.Identity;

namespace Seller.Listings.Application.Listings.Listings.Commands.Create
{
    public class CreateListingCommand : ListingCommand<CreateListingCommand>, IRequest<ListingCreateResponseModel>
    {
        public class CreateListingCommandHandler : IRequestHandler<CreateListingCommand, ListingCreateResponseModel>
        {
            private readonly IListingRepository listingRepository;
            private readonly IUserSellerRepository userSellerRepository;
            private readonly IListingFactory listingFactory;
            private readonly ICurrentUserService currentUserService;
            private readonly IBus publisher;

            public CreateListingCommandHandler(
                IListingRepository listingRepository,
                IListingFactory listingFactory,
                IUserSellerRepository userSellerRepository,
                IBus publisher,
                ICurrentUserService currentUserService)
            {
                this.listingRepository = listingRepository;
                this.listingFactory = listingFactory;
                this.publisher = publisher;
                this.currentUserService = currentUserService;
                this.userSellerRepository = userSellerRepository;
            }

            public async Task<ListingCreateResponseModel> Handle(
                CreateListingCommand request,
                CancellationToken cancellationToken)
            {
                var seller = await userSellerRepository.GetIdByUser(currentUserService.UserId, cancellationToken);

                var listing = listingFactory
                    .WithTitle(request.Title)
                    .WithImageUrl(request.ImageUrl)
                    .WithDescription(request.Description)
                    .WithPrice(request.Price)
                    .WithSellerId(seller.Id!)
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
