using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Seller.Listings.Infrastructure.Common.Listings;
using Seller.Listings.Infrastructure.Common.Persistence;
using Seller.Shared.DDD.Application.Contracts;
using Seller.Shared.DDD.Infrastructure.Events;
using DatabaseInitializer = Seller.Listings.Infrastructure.Common.Persistence.DatabaseInitializer;
using IInitializer = Seller.Listings.Infrastructure.Common.IInitializer;


namespace Seller.Listings.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddTransient<DbContext, ListingsDbContext>()
                .AddDatabase(configuration)
                .AddRepositories()
                .AddTransient<IEventDispatcher, EventDispatcher>();

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<ListingsDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(ListingsDbContext).Assembly.FullName)))
                .AddScoped<IListingDbContext>(provider => provider.GetService<ListingsDbContext>())
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
