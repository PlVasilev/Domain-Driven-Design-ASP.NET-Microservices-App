using System.Linq;
using Microsoft.EntityFrameworkCore;
using Seller.Listings.Application.Listings.Listings;
using Seller.Listings.Application.Listings.Listings.Queries.Common;
using Seller.Listings.Application.Listings.Listings.Queries.Details;
using Seller.Listings.Application.Listings.Listings.Queries.TitleAndSellerName;

namespace Seller.Listings.Infrastructure.Common.Listings.Repositories
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Persistence;
    internal class ListingRepository : DataRepository<IListingDbContext, Domain.Listings.Models.Listing>, IListingRepository
    {
        public ListingRepository(IListingDbContext db) : base(db)
        {
        }


        public async Task<IReadOnlyCollection<AllListingResponseModel>> All(CancellationToken cancellationToken = default) =>
            await this.Data.Listings
            .Where(l => l.IsDeleted == false && l.IsDeal == false)
            .OrderByDescending(l => l.Created)
            .Select(l => new AllListingResponseModel(l.Id, l.Title, l.ImageUrl, l.Price, l.Created))
            .ToListAsync(cancellationToken: cancellationToken);

        public async Task<IReadOnlyCollection<AllListingResponseModel>> Mine(string userId, CancellationToken cancellationToken = default) =>
        await this.Data.Listings
                .Where(l => l.SellerId == userId && l.IsDeleted == false && l.IsDeal == false)
                .OrderByDescending(l => l.Created)
                .Select(l => new AllListingResponseModel(l.Id, l.Title, l.ImageUrl, l.Price, l.Created))
                .ToListAsync(cancellationToken: cancellationToken);

        public async Task<DetailsListingResponseModel>
            Details(string id, CancellationToken cancellationToken = default) =>
            await this.Data
                .Listings
                .Where(l => l.IsDeleted == false && l.IsDeal == false && l.Id == id)
                .Select(l => new DetailsListingResponseModel(l.Id, l.Title, l.ImageUrl, l.Price,l.Description,l.SellerId,l.Seller.FirstName,l.Seller.LastName,l.Created))
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        public async Task<Domain.Listings.Models.Listing> GetOnlyById(string id, CancellationToken cancellationToken = default) =>
            await this.Data
                .Listings
                .Where(l => l.Id == id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        public async Task<Domain.Listings.Models.Listing> GetById(string id, CancellationToken cancellationToken = default) =>
        await this.Data
             .Listings
             .Where(l => l.Id == id  && l.IsDeleted == false && l.IsDeal == false)
             .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        public async Task<TitleAndSellerNameListingResponseModel> GetTitleAndSellerName(string id, CancellationToken cancellationToken = default)
        {
            var result = await Data
                       .Listings
                       .Include(x => x.Seller)
                       .FirstOrDefaultAsync(l => l.IsDeleted == false && l.Id == id && l.IsDeal == false, cancellationToken: cancellationToken);

                   return new TitleAndSellerNameListingResponseModel
                   {
                       SellerName = result.Seller.FirstName + " " + result.Seller.LastName,
                       Title = result.Title
                   };
        }
    }
}
