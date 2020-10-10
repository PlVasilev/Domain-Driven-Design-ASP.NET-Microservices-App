using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Seller.Listings.Application.Sales.Listings.Commands.Common;
using Seller.Listings.Domain.Sales.Factories;
using Seller.Shared.Messages.Offers;

namespace Seller.Listings.Application.Sales.Listings.Commands.Deal
{
    public class DealListingCommand : ListingCommand<DealListingCommand>, IRequest<bool>
    {
        public class DealListingCommandHandler : IRequestHandler<DealListingCommand, bool>
        {
            private readonly IListingRepository listingRepository;
            
            public DealListingCommandHandler(IListingRepository listingRepository)
            {
                this.listingRepository = listingRepository;
            }

            public async Task<bool> Handle(
                DealListingCommand request,
                CancellationToken cancellationToken)
            {
                var listing = await listingRepository.GetOnlyById(request.Id, cancellationToken);

                if (listing == null) return false;

                listing.UpdateIsDeal();
                await listingRepository.Save(listing, cancellationToken);
                return true;
            }
        }
    }
}
