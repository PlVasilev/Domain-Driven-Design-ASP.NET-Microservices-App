using System.Threading.Tasks;
using Seller.Shared.DDD.Domain;

namespace Seller.Shared.DDD.Application
{
    public interface IEventHandler<in TEvent>
        where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}
