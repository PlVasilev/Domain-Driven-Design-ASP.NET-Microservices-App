using Microsoft.Extensions.DependencyInjection;
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
          //  services
          //      .GetService<IDealerFactory>()
          //      .Should()
          //      .NotBeNull();
          //
          //  services
          //      .GetService<ICarAdFactory>()
          //      .Should()
          //      .NotBeNull();
        }
    }
}
