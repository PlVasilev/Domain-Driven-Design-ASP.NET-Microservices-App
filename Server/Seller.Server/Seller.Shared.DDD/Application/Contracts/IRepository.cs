using System.Threading;
using System.Threading.Tasks;
using Seller.Shared.DDD.Domain;

namespace Seller.Shared.DDD.Application.Contracts
{
    public interface IRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
        Task Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}
