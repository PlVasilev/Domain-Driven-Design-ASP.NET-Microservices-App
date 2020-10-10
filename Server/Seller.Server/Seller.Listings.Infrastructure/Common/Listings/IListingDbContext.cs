using Microsoft.EntityFrameworkCore;
using Seller.Listings.Domain.Sales.Models;
using IDbContext = Seller.Listings.Infrastructure.Common.Persistence.IDbContext;

namespace Seller.Listings.Infrastructure.Common.Listings
{
    public interface IListingDbContext : IDbContext
    {
        DbSet<Domain.Sales.Models.Listing> Listings { get; }
        DbSet<Deal> Deals { get; }
        DbSet<UserSeller> UserSellers { get; }


    }
}
