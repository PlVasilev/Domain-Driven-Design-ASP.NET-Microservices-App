using System;
using System.Reflection;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Seller.Offers.Application.Offers;
using Seller.Offers.Infrastructure.Common.Persistence;
using Seller.Offers.Infrastructure.Offers;
using Seller.Shared.DDD.Infrastructure.Events;
using Xunit;

namespace Seller.Offers.Infrastructure
{
    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<OfferDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<IOfferDbContext>(provider => provider
                    .GetService<OfferDbContext>())
                .AddTransient<IEventDispatcher, EventDispatcher>();

            // Act
            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IOfferRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
