using Seller.Shared.DDD.Domain;

namespace Seller.Listings.Domain.Listings.Exceptions
{
    public class InvalidUserSellerException : BaseDomainException
    {
        public InvalidUserSellerException()
        {
        }

        public InvalidUserSellerException(string error) => this.Error = error;
    }
}
