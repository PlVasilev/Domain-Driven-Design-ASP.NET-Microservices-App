using System.Threading.Tasks;
using Seller.Shared.DDD.Domain;

namespace Seller.Shared.DDD.Infrastructure.Events
{
    public interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
