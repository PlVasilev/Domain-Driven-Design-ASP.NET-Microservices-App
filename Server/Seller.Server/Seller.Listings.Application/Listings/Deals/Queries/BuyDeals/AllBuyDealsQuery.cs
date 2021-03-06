﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Listings.Application.Listings.Deals.Queries.Common;
using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Listings.Deals.Queries.BuyDeals
{
    public class AllBuyDealsQuery : EntityCommand<string>, IRequest<IReadOnlyList<DealResponseModel>>
    {
        public class AllBuyDealsQueryHandler : IRequestHandler<AllBuyDealsQuery, IReadOnlyList<DealResponseModel>>
        {
            private readonly IDealRepository dealRepository;

            public AllBuyDealsQueryHandler(IDealRepository dealRepository)
            {
                this.dealRepository = dealRepository;
            }

            public async Task<IReadOnlyList<DealResponseModel>> Handle(
                AllBuyDealsQuery request,
                CancellationToken cancellationToken)
                => await this.dealRepository.BuyDeals(request.Id, cancellationToken);


        }
    }
}
