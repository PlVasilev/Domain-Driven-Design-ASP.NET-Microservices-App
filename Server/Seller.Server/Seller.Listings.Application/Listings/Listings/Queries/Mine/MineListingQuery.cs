using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Listings.Application.Listings.Listings.Commands.Common;
using Seller.Listings.Application.Listings.Listings.Queries.Common;
using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Listings.Listings.Queries.Mine
{
    public class MineListingQuery : ListingCommand<EntityCommand<string>>, IRequest<IReadOnlyCollection<AllListingResponseModel>>
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
                => await this.listingRepository.Mine(request.SellerId, cancellationToken);


        }
    }
}
