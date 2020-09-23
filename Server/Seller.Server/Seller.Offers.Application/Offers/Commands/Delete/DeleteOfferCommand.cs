using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Shared.DDD.Application;

namespace Seller.Offers.Application.Offers.Commands.Delete
{
    public class DeleteOfferCommand : EntityCommand<string>, IRequest<Result>
    {
        public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand, Result>
        {
            private readonly IOfferRepository offerRepository;
            

            public DeleteOfferCommandHandler(
                IOfferRepository offerRepository)
            {
                this.offerRepository = offerRepository;
            }

            public async Task<Result> Handle(
                DeleteOfferCommand request,
                CancellationToken cancellationToken)
            {
                return await this.offerRepository.DeleteOffer(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}
