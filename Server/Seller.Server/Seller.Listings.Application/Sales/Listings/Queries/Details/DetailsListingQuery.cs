using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Sales.Listings.Queries.Details
{
    public class TitleAndSellerNameListingQuery : EntityCommand<string>, IRequest<DetailsListingResponseModel>
    {
        public class DetailsListingQueryHandler : IRequestHandler<TitleAndSellerNameListingQuery, DetailsListingResponseModel>
        {
            private readonly IListingRepository listingRepository;

            public DetailsListingQueryHandler(IListingRepository listingRepository)
            {
                this.listingRepository = listingRepository;
            }

            public async Task<DetailsListingResponseModel> Handle(
                TitleAndSellerNameListingQuery request,
                CancellationToken cancellationToken)
                => await this.listingRepository.Details(request.Id, cancellationToken);

        }
    }
}
