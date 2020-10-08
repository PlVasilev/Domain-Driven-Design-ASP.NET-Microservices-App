using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Sales.Listings.Queries.TitleAndSellerName
{
    public class TitleAndSellerNameListingQuery : EntityCommand<string>, IRequest<TitleAndSellerNameListingResponseModel>
    {
        public class TitleAndSellerNameListingQueryHandler : IRequestHandler<TitleAndSellerNameListingQuery, TitleAndSellerNameListingResponseModel>
        {
            private readonly IListingRepository listingRepository;

            public TitleAndSellerNameListingQueryHandler(IListingRepository listingRepository)
            {
                this.listingRepository = listingRepository;
            }

            public async Task<TitleAndSellerNameListingResponseModel> Handle(
                TitleAndSellerNameListingQuery request,
                CancellationToken cancellationToken)
                => await this.listingRepository.GetTitleAndSellerName(request.Id, cancellationToken);

        }
    }
}
