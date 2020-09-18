using FluentValidation;
using Seller.Offers.Application.Offers.Commands.Common;

namespace Seller.Offers.Application.Offers.Commands.Add
{
    public class AddOfferCommandValidator : AbstractValidator<AddOfferCommand>
    {
        public AddOfferCommandValidator() 
            => this.Include(new OfferCommandValidator<AddOfferCommand>());
    }
}
