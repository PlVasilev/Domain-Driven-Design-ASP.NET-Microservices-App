using Microsoft.EntityFrameworkCore;
using Seller.Offers.Domain.Offers.Models;
using Seller.Shared.DDD.Infrastructure.Persistence;

namespace Seller.Offers.Infrastructure.Offers
{
    public interface IOfferDbContext : IDbContext
    {
        DbSet<Offer> Offers { get; }

     
    }
}
