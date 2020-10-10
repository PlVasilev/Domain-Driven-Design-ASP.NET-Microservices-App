using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seller.Listings.Application.Sales.Deals;
using Seller.Listings.Application.Sales.Deals.Queries.Common;
using Seller.Listings.Domain.Sales.Models;
using Seller.Listings.Infrastructure.Common.Persistence;

namespace Seller.Listings.Infrastructure.Common.Listings.Repositories
{
    internal class DealRepository : DataRepository<IListingDbContext, Deal>, IDealRepository
    {
        public DealRepository(IListingDbContext db) : base(db)
        {
        }

        public async Task<IReadOnlyList<DealResponseModel>> BuyDeals(string id, CancellationToken cancellationToken = default) =>
            await Data.Deals
            .Where(x => x.BuyerId == id)
            .OrderByDescending(x => x.CreatedOn)
            .Select(x => new DealResponseModel(x.Id, x.Title, x.Price, x.CreatedOn))
            .ToListAsync(cancellationToken: cancellationToken);

        public async Task<IReadOnlyList<DealResponseModel>> SellDeals(string id, CancellationToken cancellationToken = default) =>
        await Data.Deals
            .Where(x => x.SellerId == id)
            .OrderByDescending(x => x.CreatedOn)
            .Select(x => new DealResponseModel(x.Id, x.Title, x.Price, x.CreatedOn))
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
