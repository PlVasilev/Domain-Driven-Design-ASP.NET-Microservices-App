using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seller.Shared.DDD.Application.Configuration;
using Seller.Shared.Infrastructure;

namespace Seller.Listings.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddCommonApplication(configuration);

    }
}
