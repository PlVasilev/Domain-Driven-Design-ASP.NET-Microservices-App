using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Shared.DDD.Application;

namespace Seller.Offers.Application.Offers.Queries.Mine
{
    public class MineOfferQuery : EntityCommand<string>, IRequest<IReadOnlyCollection<MineOfferOutputModel>>
    {
        public class MineOfferQueryHandler : IRequestHandler<MineOfferQuery, IReadOnlyCollection<MineOfferOutputModel>>
        {
            private readonly IOfferRepository offerRepository;

            public MineOfferQueryHandler(IOfferRepository offerRepository)
            {
                this.offerRepository = offerRepository;
            }

            public async Task<IReadOnlyCollection<MineOfferOutputModel>> Handle(
                MineOfferQuery request,
                CancellationToken cancellationToken)
                => await this.offerRepository.Mine(request.Id, cancellationToken);
        }
    }
}
