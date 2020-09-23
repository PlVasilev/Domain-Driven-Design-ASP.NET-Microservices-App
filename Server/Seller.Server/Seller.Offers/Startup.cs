using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seller.Offers.Application;
using Seller.Offers.Domain;
using Seller.Offers.Extensions;
using Seller.Offers.Infrastructure;
using Seller.Offers.Infrastructure.Offers.Messages;
using Seller.Offers.Web;
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
                .AddApplication(this.Configuration)
                .AddInfrastructure(this.Configuration)
                .AddApplicationSettings(this.Configuration)
                .AddJwtAuthentication(this.Configuration)
                .AddSwagger()
                .AddMessaging( typeof(ListingDeletedConsumer),typeof(ListingAcceptedConsumer), typeof(ListingEditedConsumer))
                .AddWebComponents();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebService(env)
                .Initialize();
        }
    }
}
