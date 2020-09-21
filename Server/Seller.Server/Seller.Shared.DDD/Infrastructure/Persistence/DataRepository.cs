using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Seller.Shared.DDD.Application.Contracts;
using Seller.Shared.DDD.Domain;

namespace Seller.Shared.DDD.Infrastructure.Persistence
{
    public abstract class DataRepository<TDbContext, TEntity> : IRepository<TEntity>
        where TDbContext : IDbContext
        where TEntity : class, IAggregateRoot
    {
        protected DataRepository(TDbContext db) => this.Data = db;

        protected TDbContext Data { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public async Task Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            this.Data.Update(entity);

            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
