using Microsoft.EntityFrameworkCore;
using Seller.Listings.Domain.Listings.Models;
using IDbContext = Seller.Listings.Infrastructure.Common.Persistence.IDbContext;

namespace Seller.Listings.Infrastructure.Common.Listings
{
    public interface IListingDbContext : IDbContext
    {
        DbSet<Domain.Listings.Models.Listing> Listings { get; }
        DbSet<Deal> Deals { get; }
        DbSet<UserSeller> UserSellers { get; }


    }
}
