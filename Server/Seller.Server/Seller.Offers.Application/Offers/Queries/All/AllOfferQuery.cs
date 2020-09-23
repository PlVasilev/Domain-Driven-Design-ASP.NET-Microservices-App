using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Shared.DDD.Application;

namespace Seller.Offers.Application.Offers.Queries.All
{
    public class AllOfferQuery : EntityCommand<string>, IRequest<IReadOnlyCollection<AllOfferOutputModel>>
    {
        public class AllOfferQueryHandler : IRequestHandler<AllOfferQuery, IReadOnlyCollection<AllOfferOutputModel>>
        {
            private readonly IOfferRepository offerRepository;

            public AllOfferQueryHandler(IOfferRepository offerRepository)
            {
                this.offerRepository = offerRepository;
            }

            public async Task<IReadOnlyCollection<AllOfferOutputModel>> Handle(
                AllOfferQuery request,
                CancellationToken cancellationToken)
                => await this.offerRepository.All(request.Id, cancellationToken);

        
        }
    }
}
