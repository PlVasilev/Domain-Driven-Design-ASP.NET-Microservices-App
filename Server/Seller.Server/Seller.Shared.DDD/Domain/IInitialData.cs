using System;
using System.Collections.Generic;

namespace Seller.Shared.DDD.Domain
{
    public interface IInitialData
    {
        Type EntityType { get; }

        IEnumerable<object> GetData();
    }
}
