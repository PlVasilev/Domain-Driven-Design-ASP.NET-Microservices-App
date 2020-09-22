using Microsoft.EntityFrameworkCore;
using Seller.Offers.Domain.Offers.Models;
using Seller.Shared.DDD.Infrastructure.Persistence;
using IDbContext = Seller.Offers.Infrastructure.Common.Persistence.IDbContext;

namespace Seller.Offers.Infrastructure.Offers
{
    public interface IOfferDbContext : IDbContext
    {
        DbSet<Offer> Offers { get; }

     
    }
}
