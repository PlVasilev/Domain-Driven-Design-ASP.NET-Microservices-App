using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Sales.UserSellers.Queries.GetByUserId
{
    public class UserSellerGetByUserIdQuery : EntityCommand<string>, IRequest<SellerIdResponseModel>
    {
        public class UserSellerGetByUserIdQueryHandler : IRequestHandler<UserSellerGetByUserIdQuery, SellerIdResponseModel>
        {
            private readonly IUserSellerRepository sellerRepository;

            public UserSellerGetByUserIdQueryHandler(IUserSellerRepository sellerRepository)
            {
                this.sellerRepository = sellerRepository;
            }

            public async Task<SellerIdResponseModel> Handle(
                UserSellerGetByUserIdQuery request,
                CancellationToken cancellationToken)
                => await this.sellerRepository.GetIdByUser(request.Id, cancellationToken);
        }
    }
}
