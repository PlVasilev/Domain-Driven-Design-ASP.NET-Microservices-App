using System.Threading.Tasks;
using Seller.Listings.Features.Seller.Services.Models;

namespace Seller.Listings.Features.Seller.Services.Interfaces
{
    public interface ISellerService
    {
        Task<SellerIdResponseModel> GetIdByUser(string userId);
        Task<bool> CreateUserSeller(string userName, string firstName, string lastName, string email, string phoneNumber,string userId);
    }
}
