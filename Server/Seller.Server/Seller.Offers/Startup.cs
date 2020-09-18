using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seller.Offers.Data;
using Seller.Offers.Domain;
using Seller.Offers.Infrastructure.Extensions;
using Seller.Offers.Messages;
using Seller.Shared.Infrastructure;

namespace Seller.Offers
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddDomain()
                .AddWebService<OffersDbContext>(this.Configuration)
                .AddAppServices()
                .AddSwagger()
                .AddMessaging( typeof(ListingDeletedConsumer),typeof(ListingAcceptedConsumer), typeof(ListingEditedConsumer))
                .AddApiControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebService(env)
                .Initialize();
        }
    }
}
