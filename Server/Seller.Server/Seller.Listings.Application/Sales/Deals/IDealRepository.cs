﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Seller.Listings.Application.Sales.Deals.Queries.Common;
using Seller.Listings.Domain.Sales.Models;
using Seller.Shared.DDD.Application.Contracts;

namespace Seller.Listings.Application.Sales.Deals
{
    public interface IDealRepository : IRepository<Deal>
    {
        public Task<IReadOnlyList<DealResponseModel>> BuyDeals(string id, CancellationToken cancellationToken = default);
        public Task<IReadOnlyList<DealResponseModel>> SellDeals(string id, CancellationToken cancellationToken = default);
    }
}
