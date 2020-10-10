using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Seller.Listings.Application.Sales.Listings.Commands.Common;
using Seller.Listings.Domain.Sales.Factories;
using Seller.Shared.Messages.Offers;

namespace Seller.Listings.Application.Sales.Listings.Commands.Edit
{
    public class DeleteListingCommand : ListingCommand<DeleteListingCommand>, IRequest<bool>
    {
        public class EditListingCommandHandler : IRequestHandler<DeleteListingCommand, bool>
        {
            private readonly IListingRepository listingRepository;
            private readonly IBus publisher;

            public EditListingCommandHandler(
                IListingRepository listingRepository,
                IBus publisher)
            {
                this.listingRepository = listingRepository;
                this.publisher = publisher;
            }

            public async Task<bool> Handle(
                DeleteListingCommand request,
                CancellationToken cancellationToken)
            {

                var listing = await listingRepository.GetById(request.Id, cancellationToken);

                if (listing == null) return false;

                var previousTitle = listing.Title;

                listing.UpdateTitle(request.Title);
                listing.UpdateDescription(request.Description);
                listing.UpdateImageUrl(request.ImageUrl);
                listing.UpdatePrice(request.Price);
                listing.UpdateCreated();

                await listingRepository.Save(listing,cancellationToken);

                if (listing.Title != previousTitle)
                {
                    await this.publisher.Publish(new ListingEditedMessage
                    {
                        ListingId = listing.Id,
                        Title = listing.Title
                    }, cancellationToken);
                }
                return true;
            }
        }
    }
}
