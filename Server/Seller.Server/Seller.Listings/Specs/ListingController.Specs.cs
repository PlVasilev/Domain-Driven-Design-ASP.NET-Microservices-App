using MyTested.AspNetCore.Mvc;
using Seller.Listings.Application.Listings.Listings.Queries.All;
using Seller.Listings.Application.Listings.Listings.Queries.Details;
using Seller.Listings.Web;
using Seller.Listings.Web.Listings;
using Xunit;

namespace Seller.Listings.Specs
{
    public class ListingControllerSpecs
    {
        [Fact]
        public void ListingDetailsShouldHaveCorrectAttributes()
            => MyController<ListingController>
                .Calling(c => c.Details(With.Default<DetailsListingQuery>()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Get)
                    .SpecifyingRoute(ApiController.Id));

        [Fact]
        public void ListingAllShouldHaveCorrectAttributes()
            => MyController<ListingController>
                .Calling(c => c.All(With.Default<AllListingQuery>()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Get)
                    .SpecifyingRoute("All"));
    }
}
