using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Seller.Offers.Domain.Offers.Factories;
using Xunit;

namespace Seller.Offers.Domain
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
                .GetService<IOfferFactory>()
                .Should()
                .NotBeNull();
          
            
        }
    }
}
