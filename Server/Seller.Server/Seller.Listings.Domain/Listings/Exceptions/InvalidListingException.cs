using Seller.Shared.DDD.Domain;

namespace Seller.Listings.Domain.Listings.Exceptions
{
    public class InvalidListingException : BaseDomainException
    {
        public InvalidListingException()
        {
        }

        public InvalidListingException(string error) => this.Error = error;
    }
}
