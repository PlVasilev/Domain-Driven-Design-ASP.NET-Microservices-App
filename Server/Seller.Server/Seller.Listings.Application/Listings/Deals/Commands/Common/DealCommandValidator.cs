using FluentValidation;
using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Listings.Deals.Commands.Common
{
    using static Shared.DDD.Domain.Models.ModelConstants.Common;
    using static Shared.DDD.Domain.Models.ModelConstants.Deal;
    public class DealCommandValidator<TCommand> : AbstractValidator<DealCommand<TCommand>> 
        where TCommand : EntityCommand<string>
    {
        public DealCommandValidator()
        {

            this.RuleFor(c => c.Title)
                .MinimumLength(MinTitleLength)
                .MaximumLength(MaxTitleLength)
                .NotEmpty();

            this.RuleFor(c => c.Price)
                .InclusiveBetween(Zero, decimal.MaxValue);

            this.RuleFor(c => c.SellerId)
                .MinimumLength(MinDescriptionLength)
                .MaximumLength(MaxDescriptionLength)
                .NotEmpty();

            this.RuleFor(c => c.BuyerId)
                .MinimumLength(MinDescriptionLength)
                .MaximumLength(MaxDescriptionLength)
                .NotEmpty();


            this.RuleFor(c => c.ListingId)
                .MinimumLength(MinGuidIdLength)
                .MaximumLength(MaxGuidIdLength)
                .NotEmpty();
        }
    }
}
