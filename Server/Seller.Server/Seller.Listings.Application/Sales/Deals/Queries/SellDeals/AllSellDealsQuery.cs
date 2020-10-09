using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Listings.Application.Sales.Deals.Queries.Common;
using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Sales.Deals.Queries.SellDeals
{
    public class AllSellDealsQuery : EntityCommand<string>, IRequest<IReadOnlyList<DealResponseModel>>
    {
        public class AllSellDealsQueryHandler : IRequestHandler<AllSellDealsQuery, IReadOnlyList<DealResponseModel>>
        {
            private readonly IDealRepository dealRepository;

            public AllSellDealsQueryHandler(IDealRepository dealRepository)
            {
                this.dealRepository = dealRepository;
            }

            public async Task<IReadOnlyList<DealResponseModel>> Handle(
                AllSellDealsQuery request,
                CancellationToken cancellationToken)
                => await this.dealRepository.SellDeals(request.Id, cancellationToken);


        }
    }
}
