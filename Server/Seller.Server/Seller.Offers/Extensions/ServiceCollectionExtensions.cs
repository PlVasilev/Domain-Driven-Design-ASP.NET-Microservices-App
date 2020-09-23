using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Seller.Offers.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services) => services
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Seller API", Version = "v1" });
            });
    }
}
