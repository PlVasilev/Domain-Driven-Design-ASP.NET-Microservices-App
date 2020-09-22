using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Offers.Application.Offers.Commands.Common;
using Seller.Offers.Domain.Offers.Factories;
using Seller.Shared.DDD.Application.Contracts;

namespace Seller.Offers.Application.Offers.Commands.Add
{
    public class AddOfferCommand : OfferCommand<AddOfferCommand>, IRequest<AddOfferOutputModel>
    {
        public class AddOfferCommandHandler : IRequestHandler<AddOfferCommand, AddOfferOutputModel>
        {
            private readonly IOfferRepository offerRepository;
            private readonly IOfferFactory offerFactory;

            public AddOfferCommandHandler(
                IOfferRepository offerRepository,
                IOfferFactory offerFactory)
            {
                this.offerRepository = offerRepository;
                this.offerFactory = offerFactory;
            }

            public async Task<AddOfferOutputModel> Handle(
                AddOfferCommand request, 
                CancellationToken cancellationToken)
            {


                var offer = this.offerFactory
                    .WithCreatorId(request.CreatorId)
                    .WithCreatorName(request.CreatorName)
                    .WithListingId(request.ListingId)
                    .WithPrice(request.Price)
                    .WithTitle(request.Title)
                    .Build();

                await this.offerRepository.Save(offer, cancellationToken);
                string id = offer.Id;
                return new AddOfferOutputModel(
                    offer.Id, offer.ListingId, offer.Price, offer.Created, offer.CreatorId, offer.IsAccepted, offer.Title, offer.CreatorName);
            }
        }
    }
}
