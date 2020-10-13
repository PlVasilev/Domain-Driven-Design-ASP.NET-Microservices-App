using System;
using Bogus;
using FakeItEasy;

namespace Seller.Listings.Domain.Listings.Models
{
    public class UserSellerFakes
    {
        public class UserSellerDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Listing);

            public object? Create(Type type) => Data.GetUserSeller();

            public Priority Priority => Priority.Default;
        }

        public static class Data
        {
            public static UserSeller? GetUserSeller()
                => new Faker<UserSeller>()
                    .CustomInstantiator(f => new UserSeller (
                            "User",
                            "FirstName",
                            "LastName",
                            "User@user.user",
                            "05555555",
                            "0123457890123457890123457890123457890"))
                    .Generate()
                    .SetId("UserSeller123457890123457890123457890123457890");
        }
    }
}
