using System;
using FluentAssertions;
using Seller.Listings.Domain.Listings.Exceptions;
using Xunit;

namespace Seller.Listings.Domain.Listings.Factories
{
    public class ListingFactorySpecs
    {
        [Fact]
        public void BuildShouldThrowExceptionIfPriceIsNegative()
        {
            // Assert
            var listingFactory = new ListingFactory();

            // Act
            Action act = () => listingFactory
                .WithTitle("Title")
                .WithImageUrl("https://images.unsplash.com/photo-1602405384239-d761a4f0b6cf?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1353&q=80")
                .WithPrice(-1)
                .WithDescription("Description")
                .WithSellerId("123457890123457890123457890123457890")
                .Build();

            // Assert
            act.Should().Throw<InvalidListingException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfSellerIdIsNotGuidLength()
        {
            // Assert
            var listingFactory = new ListingFactory();

            // Act
            Action act = () => listingFactory
                .WithTitle("Title")
                .WithImageUrl("https://images.unsplash.com/photo-1602405384239-d761a4f0b6cf?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1353&q=80")
                .WithPrice(100)
                .WithDescription("Description")
                .WithSellerId("12")
                .Build();

            // Assert
            act.Should().Throw<InvalidUserSellerException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfThereIsNoTitle()
        {
            // Assert
            var listingFactory = new ListingFactory();

            // Act
            Action act = () => listingFactory
                .WithImageUrl("https://images.unsplash.com/photo-1602405384239-d761a4f0b6cf?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1353&q=80")
                .WithPrice(100)
                .WithDescription("Description")
                .WithSellerId("12")
                .Build();

            // Assert
            act.Should().Throw<InvalidListingException>();
        }

        [Fact]
        public void BuildShouldCreateCarAdIfEveryPropertyIsSet()
        {
            // Assert
            var listingFactory = new ListingFactory();

            // Act
            var listing = listingFactory
                .WithTitle("Title")
                .WithImageUrl("https://images.unsplash.com/photo-1602405384239-d761a4f0b6cf?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1353&q=80")
                .WithPrice(100)
                .WithDescription("Description")
                .WithSellerId("123457890123457890123457890123457890")
                .Build();

            // Assert
            listing.Should().NotBeNull();
        }
    }
}
