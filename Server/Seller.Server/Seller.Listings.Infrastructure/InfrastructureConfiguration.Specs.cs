using System;
using System.Reflection;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Seller.Listings.Application.Listings.Deals;
using Seller.Listings.Application.Listings.Listings;
using Seller.Listings.Application.Listings.UserSellers;
using Seller.Listings.Infrastructure.Common.Listings;
using Seller.Listings.Infrastructure.Common.Persistence;
using Seller.Shared.DDD.Infrastructure.Events;
using Xunit;

namespace Seller.Listings.Infrastructure
{
    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<ListingsDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<IListingDbContext>(provider => provider
                    .GetService<ListingsDbContext>())
                .AddTransient<IEventDispatcher, EventDispatcher>();

            // Act
            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IListingRepository>()
                .Should()
                .NotBeNull();

            services
                .GetService<IUserSellerRepository>()
                .Should()
                .NotBeNull();

            services
                .GetService<IDealRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
