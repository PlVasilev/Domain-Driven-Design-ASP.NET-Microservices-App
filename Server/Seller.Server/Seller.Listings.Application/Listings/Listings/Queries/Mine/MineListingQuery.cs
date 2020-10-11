using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Listings.Application.Listings.Listings.Commands.Common;
using Seller.Listings.Application.Listings.Listings.Queries.Common;
using Seller.Listings.Application.Listings.UserSellers;
using Seller.Shared.DDD.Application;
using Seller.Shared.Services.Identity;

namespace Seller.Listings.Application.Listings.Listings.Queries.Mine
{
    public class MineListingQuery : ListingCommand<EntityCommand<string>>, IRequest<IReadOnlyCollection<AllListingResponseModel>>
    {
        public class MineListingQueryHandler : IRequestHandler<MineListingQuery, IReadOnlyCollection<AllListingResponseModel>>
        {
            private readonly IListingRepository listingRepository;
            private readonly IUserSellerRepository userSellerRepository;
            private readonly ICurrentUserService currentUserService;

            public MineListingQueryHandler(IListingRepository listingRepository, IUserSellerRepository userSellerRepository, ICurrentUserService currentUserService)
            {
                this.listingRepository = listingRepository;
                this.userSellerRepository = userSellerRepository;
                this.currentUserService = currentUserService;
      
            }

            public async Task<IReadOnlyCollection<AllListingResponseModel>> Handle(
                MineListingQuery request,
                CancellationToken cancellationToken)
            {
                var seller = await userSellerRepository.GetIdByUser(currentUserService.UserId, cancellationToken);
                return await this.listingRepository.Mine(seller.Id!, cancellationToken);
            }
        }
    }
}
