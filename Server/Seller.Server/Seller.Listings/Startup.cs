using Seller.Listings.Application;
using Seller.Listings.Domain;
using Seller.Listings.Infrastructure;
using Seller.Listings.Web;

namespace Seller.Listings
{
    using Seller.Shared.Infrastructure;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddDomain()
                .AddApplication(this.Configuration)
                .AddInfrastructure(this.Configuration)
                .AddApplicationSettings(this.Configuration)
                .AddJwtAuthentication(this.Configuration)
                .AddSwagger()
                .AddMessaging()
                .AddWebComponents();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
            app.UseWebService(env)
                .Initialize();

    }
}
