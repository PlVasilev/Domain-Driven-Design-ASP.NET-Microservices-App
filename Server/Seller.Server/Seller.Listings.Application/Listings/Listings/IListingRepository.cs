using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Seller.Listings.Application.Listings.Listings.Queries.Common;
using Seller.Listings.Application.Listings.Listings.Queries.Details;
using Seller.Listings.Application.Listings.Listings.Queries.TitleAndSellerName;
using Seller.Listings.Domain.Listings.Models;
using Seller.Shared.DDD.Application.Contracts;

namespace Seller.Listings.Application.Listings.Listings
{
    public interface IListingRepository :  IRepository<Listing>
    {
        public Task<IReadOnlyCollection<AllListingResponseModel>> All(CancellationToken cancellationToken = default);
        public Task<IReadOnlyCollection<AllListingResponseModel>> Mine(string userId,
            CancellationToken cancellationToken = default);
        public Task<DetailsListingResponseModel> Details(string id, CancellationToken cancellationToken = default);
        public Task<Listing> GetOnlyById(string id, CancellationToken cancellationToken = default);
        public Task<Listing> GetById(string id, CancellationToken cancellationToken = default);
        public  Task<TitleAndSellerNameListingResponseModel> GetTitleAndSellerName(string id, CancellationToken cancellationToken = default);
    }
}
