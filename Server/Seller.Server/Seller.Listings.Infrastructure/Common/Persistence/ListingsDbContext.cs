using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seller.Listings.Domain.Listings.Models;
using Seller.Listings.Infrastructure.Common.Listings;
using Seller.Shared.DDD.Domain.Models;
using Seller.Shared.DDD.Infrastructure.Events;

namespace Seller.Listings.Infrastructure.Common.Persistence
{
    internal class ListingsDbContext : DbContext, IListingDbContext

    {
        private readonly IEventDispatcher? eventDispatcher;
        private bool eventsDispatched;

        

        public ListingsDbContext(
            DbContextOptions<ListingsDbContext> options,
            IEventDispatcher eventDispatcher)
            : base(options)
        {
            this.eventDispatcher = eventDispatcher;

            this.eventsDispatched = false;
        }

        public DbSet<Domain.Listings.Models.Listing> Listings { get; set; } = default!;
        public DbSet<Deal> Deals { get; set; } = default!;
        public DbSet<UserSeller> UserSellers { get; set; } = default!;


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entriesModified = 0;

            if (!this.eventsDispatched) // TODO !
            {
                var entities = this.ChangeTracker
                    .Entries<IEntity>()
                    .Select(e => e.Entity)
                    .Where(e => e.Events.Any())
                    .ToArray();

                foreach (var entity in entities)
                {
                    var events = entity.Events.ToArray();

                    entity.ClearEvents();

                    foreach (var domainEvent in events)
                    {
                        if (this.eventDispatcher != null)
                        {
                            await this.eventDispatcher.Dispatch(domainEvent);
                        }
                        
                    }
                }

                this.eventsDispatched = true;

                entriesModified = await base.SaveChangesAsync(cancellationToken);
            }

            return entriesModified;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Domain.Listings.Models.Listing>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder
                .Entity<Deal>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder
                .Entity<UserSeller>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Domain.Listings.Models.Listing>()
                .HasOne<Deal>(a => a.Deal)
                .WithOne(b => b.Listing!)
                .HasForeignKey<Deal>(a => a.ListingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Deal>()
                .HasOne(u => u.Seller)
                .WithMany(s => s!.SaleDeals)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Deal>()
                .HasOne(u => u.Buyer)
                .WithMany(s => s!.BuyDeals)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
