using System.Collections.Generic;
using Seller.Listings.Domain.Listings.Exceptions;
using Seller.Shared.DDD.Domain;
using Seller.Shared.DDD.Domain.Models;

namespace Seller.Listings.Domain.Listings.Models
{
    using static Shared.DDD.Domain.Models.ModelConstants.Common;
    public class UserSeller : Entity<string>, IAggregateRoot
    {
        
        internal UserSeller(string userName, string firstName, string lastName, string email, string phoneNumber, string userId)
        {
            Validate( userName,  firstName,  lastName,  email,  phoneNumber,  userId);

            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            UserId = userId;
            IsDeleted = false;
        }

        private UserSeller()
        {
            UserName = default!;
            FirstName = default!;
            LastName = default!;
            Email = default!;
            PhoneNumber = default!;
            UserId = default!;
            IsDeleted = default;
        }

        public string UserName { get;private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsDeleted { get; private set; }
        public string UserId { get; private set; }

        public IEnumerable<Deal> SaleDeals { get; set; } = new List<Deal>();
        public IEnumerable<Deal> BuyDeals { get; set; } = new List<Deal>();
        public IEnumerable<Listing> Listings { get; set; } = new List<Listing>();

        private void Validate(string userName, string firstName, string lastName, string email, string phoneNumber, string userId)
        {
            ValidateUserName(userName);
            ValidateFirstName(firstName);
            ValidateLastName(lastName);
            ValidateEmailLength(email);
            ValidatePhoneNumber(phoneNumber);
            ValidateUserId(userId);
        }

        private void ValidateUserName(string userName)
            => Guard.ForStringLength<InvalidUserSellerException>(
                userName,
                MinNameLength,
                MaxNameLength,
                nameof(this.UserName));

        private void ValidateFirstName(string firstName)
            => Guard.ForStringLength<InvalidUserSellerException>(
                firstName,
                MinNameLength,
                MaxNameLength,
                nameof(this.FirstName));

        private void ValidateLastName(string lastName)
            => Guard.ForStringLength<InvalidUserSellerException>(
                lastName,
                MinNameLength,
                MaxNameLength,
                nameof(this.LastName));

        private void ValidateEmailLength(string email)
            => Guard.ForStringLength<InvalidUserSellerException>(
                email,
                MinNameLength,
                MaxNameLength,
                nameof(this.Email));

        private void ValidatePhoneNumber(string phoneNumber)
            => Guard.ForStringLength<InvalidUserSellerException>(
                phoneNumber,
                MinNameLength,
                MaxNameLength,
                nameof(this.PhoneNumber));


        private void ValidateUserId(string userId)
            => Guard.ForStringLength<InvalidUserSellerException>(
                userId,
                MinGuidIdLength,
                MaxGuidIdLength,
                nameof(this.UserId));
    }
}