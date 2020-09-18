using System;
using System.Collections.Generic;
using System.Text;
using Seller.Offers.Domain.Offers.Models;
using Seller.Shared.DDD.Domain;

namespace Seller.Offers.Domain.Offers.Factories
{
    public interface IOfferFactory : IFactory<Offer>
    {
        IOfferFactory WithCreatorId(string creatorId);

        IOfferFactory WithTitle(string title);

        IOfferFactory WithPrice(decimal price);

        IOfferFactory WithListingId(string listingId);

        IOfferFactory WithCreatorName(string creatorName);

        

 
    }
}
