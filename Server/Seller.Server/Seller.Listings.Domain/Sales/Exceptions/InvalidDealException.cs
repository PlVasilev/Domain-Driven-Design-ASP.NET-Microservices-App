using Seller.Shared.DDD.Domain;

namespace Seller.Listings.Domain.Sales.Exceptions
{
    public class InvalidDealException : BaseDomainException
    {
        public InvalidDealException()
        {
        }

        public InvalidDealException(string error) => this.Error = error;
    }
}
