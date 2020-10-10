using System.Threading;
using System.Threading.Tasks;
using Seller.Listings.Application.Listings.UserSellers.Queries.GetByUserId;
using Seller.Listings.Domain.Listings.Models;
using Seller.Shared.DDD.Application.Contracts;

namespace Seller.Listings.Application.Listings.UserSellers
{
    public interface IUserSellerRepository : IRepository<UserSeller>
    {
        public Task<SellerIdResponseModel> GetIdByUser(string userId, CancellationToken cancellationToken = default);
    }
}
