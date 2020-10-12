using MyTested.AspNetCore.Mvc;
using Seller.Listings.Application.Listings.Listings.Queries.Details;
using Seller.Listings.Web;
using Seller.Listings.Web.Listings;
using Xunit;

namespace Seller.Listings.Specs
{
    public class ListingControllerSpecs
    {
        [Fact]
        public void DetailsShouldHaveCorrectAttributes()
            => MyController<ListingController>
                .Calling(c => c.Details(With.Default<DetailsListingQuery>()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Get)
                    .SpecifyingRoute(ApiController.Id));
    }
}
