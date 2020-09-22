using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seller.Offers.Infrastructure.Common.Persistence;
using Seller.Offers.Infrastructure.Offers;
using Seller.Shared.DDD.Application.Contracts;
using Seller.Shared.DDD.Infrastructure.Events;
using DatabaseInitializer = Seller.Offers.Infrastructure.Common.Persistence.DatabaseInitializer;
using IInitializer = Seller.Offers.Infrastructure.Common.IInitializer;

namespace Seller.Offers.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddTransient<DbContext, OfferDbContext>()
                .AddDatabase(configuration)
                .AddRepositories()
                .AddTransient<IEventDispatcher, EventDispatcher>();

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<OfferDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(OfferDbContext).Assembly.FullName)))
                .AddScoped<IOfferDbContext>(provider => provider.GetService<OfferDbContext>())
                .AddTransient<IInitializer, DatabaseInitializer>();

        internal static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IRepository<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime());
    }
}
