using Seller.Shared.DDD.Domain;

namespace Seller.Offers.Domain.Offers.Exceptions
{
    public class InvalidOfferException : BaseDomainException
    {
        public InvalidOfferException()
        {
        }

        public InvalidOfferException(string error) => this.Error = error;
    }
}
