using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace Seller.Listings.Domain.Listings.Models
{
    public class ListingSpecs
    {
        [Fact]
        public void ChangeAvailabilityShouldMutateIsAvailable()
        {
            // Arrange
            var carAd = A.Dummy<Listing>();

            // Act
            carAd.UpdateIsDeal();

            // Assert
            carAd.IsDeal.Should().BeTrue();
        }
    }
}
