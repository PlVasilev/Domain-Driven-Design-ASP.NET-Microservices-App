using System.Collections.Generic;

namespace Seller.Shared.DDD.Domain.Models
{
    public interface IEntity
    {
        IReadOnlyCollection<IDomainEvent> Events { get; }

        void ClearEvents();
    }
}
