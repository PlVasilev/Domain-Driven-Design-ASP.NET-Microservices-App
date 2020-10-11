using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Seller.Listings.Application.Listings.Listings.Commands.Common;
using Seller.Shared.Messages.Offers;

namespace Seller.Listings.Application.Listings.Listings.Commands.Delete
{
    public class DeleteListingCommand : ListingCommand<DeleteListingCommand>, IRequest<bool>
    {
        public class DeleteListingCommandHandler : IRequestHandler<DeleteListingCommand, bool>
        {
            private readonly IListingRepository listingRepository;
            private readonly IBus publisher;

            public DeleteListingCommandHandler(IListingRepository listingRepository, IBus publisher)
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

                listing.UpdateIsDeleted();

                await listingRepository.Save(listing, cancellationToken);

                await this.publisher.Publish(new ListingDeletedMessage
                {
                    ListingId = listing.Id
                }, cancellationToken);
                return true;
            }
        }
    }
}
