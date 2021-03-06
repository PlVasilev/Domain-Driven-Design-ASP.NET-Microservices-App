﻿using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Seller.Listings.Domain.Listings.Factories;
using Xunit;

namespace Seller.Listings.Domain
{
    public class DomainConfigurationSpecs
    {
        [Fact]
        public void AddDomainShouldRegisterFactories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            var services = serviceCollection
                .AddDomain()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IListingFactory>()
                .Should()
                .NotBeNull();
          
            services
                .GetService<IUserSellerFactory>()
                .Should()
                .NotBeNull();

            services
                .GetService<IDealFactory>()
                .Should()
                .NotBeNull();
        }
    }
}
