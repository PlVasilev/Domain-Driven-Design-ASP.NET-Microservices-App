using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Offers.Application.Offers.Commands.Delete;
using Seller.Shared.DDD.Application;

namespace Seller.Offers.Application.Offers.Commands.Accept
{
    public class AcceptOfferCommand : EntityCommand<string>, IRequest<bool>
    {
        public class AcceptOfferCommandHandler : IRequestHandler<AcceptOfferCommand, bool>
        {
            private readonly IOfferRepository offerRepository;


            public AcceptOfferCommandHandler(
                IOfferRepository offerRepository)
            {
                this.offerRepository = offerRepository;
            }

            public async Task<bool> Handle(
                AcceptOfferCommand request,
                CancellationToken cancellationToken)
            {
                return await this.offerRepository.Accept(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}
