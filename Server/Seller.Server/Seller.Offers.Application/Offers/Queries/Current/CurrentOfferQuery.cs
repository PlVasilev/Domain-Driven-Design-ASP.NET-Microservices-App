using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Shared.DDD.Application;

namespace Seller.Offers.Application.Offers.Queries.Current
{
    public class CurrentOfferQuery : EntityCommand<string>, IRequest<decimal>
    {
        public string CreatorId { get; set; } = default!;

        public string ListingId { get; set; } = default!;

        
        public class CurrentOfferQueryHandler : IRequestHandler<CurrentOfferQuery, decimal>
        {
            private readonly IOfferRepository offerRepository;

            public CurrentOfferQueryHandler(IOfferRepository offerRepository)
            {
                this.offerRepository = offerRepository;
            }

            public async Task<decimal> Handle(
                CurrentOfferQuery request,
                CancellationToken cancellationToken)
                => await this.offerRepository.GetCurrentOffer(request.CreatorId, request.ListingId, cancellationToken);
        }
    }
}
