using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Listings.Application.Listings.Listings.Commands.Common;

namespace Seller.Listings.Application.Listings.Listings.Commands.Delete
{
    public class DeleteListingCommand : ListingCommand<DeleteListingCommand>, IRequest<bool>
    {
        public class DeleteListingCommandHandler : IRequestHandler<DeleteListingCommand, bool>
        {
            private readonly IListingRepository listingRepository;

            public DeleteListingCommandHandler(IListingRepository listingRepository)
            {
                this.listingRepository = listingRepository;
            }

            public async Task<bool> Handle(
                DeleteListingCommand request,
                CancellationToken cancellationToken)
            {

                var listing = await listingRepository.GetById(request.Id, cancellationToken);

                if (listing == null) return false;

                listing.UpdateIsDeleted();

                await listingRepository.Save(listing, cancellationToken);

                return true;
            }
        }
    }
}
