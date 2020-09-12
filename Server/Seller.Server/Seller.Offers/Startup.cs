using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seller.Offers.Data;
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
                .AddWebService<OffersDbContext>(this.Configuration)
                .AddAppServices()
                .AddSwagger()
                .AddMessaging( typeof(ListingDeletedConsumer),typeof(ListingAcceptedConsumer), typeof(ListingEditedConsumer))
                //.AddMassTransit(mt =>
                //{
                //    mt.AddConsumer<ListingDeletedConsumer>();
                //    mt.AddConsumer<ListingAcceptedConsumer>();
                //    mt.AddBus(bus => Bus.Factory.CreateUsingRabbitMq(cfg =>
                //    {
                //        cfg.Host("localhost");
                //        cfg.ReceiveEndpoint(nameof(ListingDeletedConsumer), endpoint =>
                //        {
                //            endpoint.ConfigureConsumer<ListingDeletedConsumer>(bus);
                //        });
                //        cfg.ReceiveEndpoint(nameof(ListingAcceptedConsumer), endpoint =>
                //        {
                //            endpoint.ConfigureConsumer<ListingAcceptedConsumer>(bus);
                //        });
                //    }));
                //})
                //.AddMassTransitHostedService()
                .AddApiControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebService(env)
                .Initialize();
        }
    }
}
