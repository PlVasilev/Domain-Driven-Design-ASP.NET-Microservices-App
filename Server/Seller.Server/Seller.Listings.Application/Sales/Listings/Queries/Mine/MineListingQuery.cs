using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Listings.Application.Sales.Listings.Queries.Common;
using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Sales.Listings.Queries.Mine
{
    public class MineListingQuery : EntityCommand<string>, IRequest<IReadOnlyCollection<AllListingResponseModel>>
    {
        public class MineListingQueryHandler : IRequestHandler<MineListingQuery, IReadOnlyCollection<AllListingResponseModel>>
        {
            private readonly IListingRepository listingRepository;

            public MineListingQueryHandler(IListingRepository listingRepository)
            {
                this.listingRepository = listingRepository;
            }

            public async Task<IReadOnlyCollection<AllListingResponseModel>> Handle(
                MineListingQuery request,
                CancellationToken cancellationToken)
                => await this.listingRepository.All(cancellationToken);


        }
    }
}
