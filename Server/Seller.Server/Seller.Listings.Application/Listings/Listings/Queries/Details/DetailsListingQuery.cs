using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Listings.Listings.Queries.Details
{
    public class DetailsListingQuery : EntityCommand<string>, IRequest<DetailsListingResponseModel>
    {
        public class DetailsListingQueryHandler : IRequestHandler<DetailsListingQuery, DetailsListingResponseModel>
        {
            private readonly IListingRepository listingRepository;

            public DetailsListingQueryHandler(IListingRepository listingRepository)
            {
                this.listingRepository = listingRepository;
            }

            public async Task<DetailsListingResponseModel> Handle(
                DetailsListingQuery request,
                CancellationToken cancellationToken)
                => await this.listingRepository.Details(request.Id, cancellationToken);

        }
    }
}
