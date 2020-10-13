using System;
using Bogus;
using FakeItEasy;

namespace Seller.Listings.Domain.Listings.Models
{
    public class CarAdFakes
    {
        public class CarAdDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Listing);

            public object? Create(Type type) => Data.GetListing();

            public Priority Priority => Priority.Default;
        }

        public static class Data
        {
            public static Listing? GetListing()
                => (Listing?) new Faker<Listing>()
                    .CustomInstantiator(f => new Listing(
                        "Title",
                        "Description",
                        "https://images.unsplash.com/photo-1602405384239-d761a4f0b6cf?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1353&q=80",100, "0123457890123457890123457890123457890"))
                    .Generate()
                    .SetId("Listing123457890123457890123457890123457890");
        }
    }
}
