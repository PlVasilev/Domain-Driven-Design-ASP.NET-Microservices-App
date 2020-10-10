using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seller.Listings.Application.Listings.UserSellers;
using Seller.Listings.Application.Listings.UserSellers.Queries.GetByUserId;
using Seller.Listings.Domain.Listings.Models;
using Seller.Listings.Infrastructure.Common.Persistence;

namespace Seller.Listings.Infrastructure.Common.Listings.Repositories
{
    internal class UserSellerRepository : DataRepository<IListingDbContext, UserSeller>, IUserSellerRepository
    {
        public UserSellerRepository(IListingDbContext db) : base(db)
        {
        }

        public async Task<SellerIdResponseModel> GetIdByUser(string userId, CancellationToken cancellationToken = default)
        {
            var user = await Data.UserSellers.FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken: cancellationToken);
            
            return new SellerIdResponseModel(user.Id);
        }
    }
}
