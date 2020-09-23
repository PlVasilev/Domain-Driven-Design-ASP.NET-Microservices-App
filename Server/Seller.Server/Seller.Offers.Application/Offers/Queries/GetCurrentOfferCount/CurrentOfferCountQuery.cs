using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Shared.DDD.Application;

namespace Seller.Offers.Application.Offers.Queries.GetCurrentOfferCount
{
    public class CurrentOfferCountQuery : EntityCommand<string>, IRequest<int>
    {
        public class CurrentOfferQueryHandler : IRequestHandler<CurrentOfferCountQuery, int>
        {
            private readonly IOfferRepository offerRepository;

            public CurrentOfferQueryHandler(IOfferRepository offerRepository)
            {
                this.offerRepository = offerRepository;
            }

            public async Task<int> Handle(
                CurrentOfferCountQuery request,
                CancellationToken cancellationToken)
                => await this.offerRepository.GetOffersCount(request.Id, cancellationToken);
        }
    }
}
