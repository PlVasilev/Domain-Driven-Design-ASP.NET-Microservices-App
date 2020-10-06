using Seller.Listings.Domain.Sales.Models;
using Seller.Shared.DDD.Domain;

namespace Seller.Listings.Domain.Sales.Factories
{
    public interface IUserSellerFactory : IFactory<UserSeller>
    {
        IUserSellerFactory WithUserName(string userName);
        IUserSellerFactory WithFirstName(string firstName);
        IUserSellerFactory WithLastName(string lastName);
        IUserSellerFactory WithEmail(string email);
        IUserSellerFactory WithPhoneNumber(string phoneNumber);
        IUserSellerFactory WithUserId(string userId);
    }
}
