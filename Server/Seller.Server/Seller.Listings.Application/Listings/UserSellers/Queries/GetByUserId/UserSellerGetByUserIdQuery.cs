using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Shared.DDD.Application;
using Seller.Shared.Services.Identity;

namespace Seller.Listings.Application.Listings.UserSellers.Queries.GetByUserId
{
    public class UserSellerGetByUserIdQuery : EntityCommand<string>, IRequest<SellerIdResponseModel>
    {
        public class UserSellerGetByUserIdQueryHandler : IRequestHandler<UserSellerGetByUserIdQuery, SellerIdResponseModel>
        {
            private readonly IUserSellerRepository sellerRepository;
            private readonly ICurrentUserService currentUserService;

            public UserSellerGetByUserIdQueryHandler(IUserSellerRepository sellerRepository, ICurrentUserService currentUserService)
            {
                this.sellerRepository = sellerRepository;
                this.currentUserService = currentUserService;
            }

            public async Task<SellerIdResponseModel> Handle(
                UserSellerGetByUserIdQuery request,
                CancellationToken cancellationToken)
                => await this.sellerRepository.GetIdByUser(currentUserService.UserId, cancellationToken);
        }
    }
}
