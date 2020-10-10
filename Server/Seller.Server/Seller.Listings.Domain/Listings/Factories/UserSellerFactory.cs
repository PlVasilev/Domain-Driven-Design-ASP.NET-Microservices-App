using Seller.Listings.Domain.Listings.Models;

namespace Seller.Listings.Domain.Listings.Factories
{
   public class UserSellerFactory : IUserSellerFactory
    {
        private string userName = default!;
        private string firstName = default!;
        private string lastName = default!;
        private string email = default!;
        private string phoneNumber = default!;
        private string userId = default!;

        public UserSeller Build()
        {
            return new UserSeller(
                this.userName,
                this.firstName,
                this.lastName,
                this.email,
                this.phoneNumber,
                this.userId);
        }

        public IUserSellerFactory WithUserName(string userName)
        {
            this.userName = userName;
            return this;
        }

        public IUserSellerFactory WithFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public IUserSellerFactory WithLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public IUserSellerFactory WithEmail(string email)
        {
            this.email = email;
            return this;
        }

        public IUserSellerFactory WithPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            return this;
        }

        public IUserSellerFactory WithUserId(string userId)
        {
            this.userId = userId;
            return this;
        }
    }
}
