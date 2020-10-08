using System.Threading;
using System.Threading.Tasks;
using Seller.Listings.Application.Sales.UserSellers.Commands.Create;
using Seller.Listings.Application.Sales.UserSellers.Queries.GetByUserId;
using Seller.Listings.Domain.Sales.Models;
using Seller.Shared.DDD.Application.Contracts;

namespace Seller.Listings.Application.Sales.UserSellers
{
    public interface IUserSellerRepository : IRepository<UserSeller>
    {
        public Task<bool> CreateUserSeller(string userName, string firstName, string lastName, string email,
            string phoneNumber, string userId, CancellationToken cancellationToken = default);

        public Task<SellerIdResponseModel> GetIdByUser(string userId, CancellationToken cancellationToken = default);
    }
}
