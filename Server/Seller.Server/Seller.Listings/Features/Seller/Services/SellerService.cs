using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seller.Listings.Data;
using Seller.Listings.Data.Models;
using Seller.Listings.Features.Seller.Services.Interfaces;
using Seller.Listings.Features.Seller.Services.Models;
using Seller.Shared.Services.Identity;

namespace Seller.Listings.Features.Seller.Services
{
    public class SellerService : ISellerService
    {
        private readonly ListingsDbContext context;


        public SellerService(ListingsDbContext context)
        {
            this.context = context;

        }
        public async Task<bool> CreateUserSeller(string userNmae, string firstName, string lastName, string email, string phoneNumber, string userId)
        {

            var userSeller = new UserSeller
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userNmae,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                UserId = userId
            };

            context.Add(userSeller);
            int result = await context.SaveChangesAsync();

            if (result == 0) return false;
            return true;
        }

        public async Task<SellerIdResponseModel> GetIdByUser(string userId)
        {
          var user = await context.UserSellers.FirstOrDefaultAsync(x => x.UserId == userId);

          return new SellerIdResponseModel {Id = user.Id};
        }
            
    }
}
