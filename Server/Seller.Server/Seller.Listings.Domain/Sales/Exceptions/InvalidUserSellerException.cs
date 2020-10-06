using Seller.Shared.DDD.Domain;

namespace Seller.Listings.Domain.Sales.Exceptions
{
    public class InvalidUserSellerException : BaseDomainException
    {
        public InvalidUserSellerException()
        {
        }

        public InvalidUserSellerException(string error) => this.Error = error;
    }
}
