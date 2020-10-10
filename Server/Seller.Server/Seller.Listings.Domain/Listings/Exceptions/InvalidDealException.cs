using Seller.Shared.DDD.Domain;

namespace Seller.Listings.Domain.Listings.Exceptions
{
    public class InvalidDealException : BaseDomainException
    {
        public InvalidDealException()
        {
        }

        public InvalidDealException(string error) => this.Error = error;
    }
}
