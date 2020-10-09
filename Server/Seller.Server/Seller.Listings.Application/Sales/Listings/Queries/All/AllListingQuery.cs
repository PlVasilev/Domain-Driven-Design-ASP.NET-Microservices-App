using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Listings.Application.Sales.Listings.Queries.Common;
using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Sales.Listings.Queries.All
{
    public class AllListingQuery : EntityCommand<string>, IRequest<IReadOnlyCollection<AllListingResponseModel>>
    {
        public class AllListingQueryHandler : IRequestHandler<AllListingQuery, IReadOnlyCollection<AllListingResponseModel>>
        {
            private readonly IListingRepository listingRepository;

            public AllListingQueryHandler(IListingRepository listingRepository)
            {
                this.listingRepository = listingRepository;
            }

            public async Task<IReadOnlyCollection<AllListingResponseModel>> Handle(
                AllListingQuery request,
                CancellationToken cancellationToken)
                => await this.listingRepository.All(cancellationToken);


        }
    }
}
