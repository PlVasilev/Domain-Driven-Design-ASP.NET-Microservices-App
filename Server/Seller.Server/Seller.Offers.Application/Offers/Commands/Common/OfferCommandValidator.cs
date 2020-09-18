namespace Seller.Offers.Application.Offers.Commands.Common
{
    using FluentValidation;
    using Seller.Shared.DDD.Application;
    using static Seller.Shared.DDD.Domain.Models.ModelConstants.Common;
    using static Seller.Shared.DDD.Domain.Models.ModelConstants.Offer;
    public class OfferCommandValidator<TCommand> : AbstractValidator<OfferCommand<TCommand>> 
        where TCommand : EntityCommand<string>
    {
        public OfferCommandValidator()
        {

            this.RuleFor(c => c.CreatorId)
                .MinimumLength(MinGuidIdLength)
                .MaximumLength(MaxGuidIdLength)
                .NotEmpty();

            this.RuleFor(c => c.ListingId)
                .MinimumLength(MinGuidIdLength)
                .MaximumLength(MaxGuidIdLength)
                .NotEmpty();

            this.RuleFor(c => c.Price)
                .InclusiveBetween(Zero, decimal.MaxValue);

            this.RuleFor(c => c.Title)
                .MinimumLength(MinTitleLength)
                .MaximumLength(MaxTitleLength)
                .NotEmpty();


            this.RuleFor(c => c.CreatorName)
                .MinimumLength(MinCreatorNameLength)
                .MaximumLength(MaxCreatorNameLength)
                .NotEmpty();
        }
    }
}
