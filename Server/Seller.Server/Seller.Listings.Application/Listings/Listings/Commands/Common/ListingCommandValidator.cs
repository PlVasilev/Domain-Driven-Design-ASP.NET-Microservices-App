using FluentValidation;
using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Listings.Listings.Commands.Common
{
    using static Shared.DDD.Domain.Models.ModelConstants.Common;
    using static Shared.DDD.Domain.Models.ModelConstants.Listing;
    public class DealCommandValidator<TCommand> : AbstractValidator<ListingCommand<TCommand>> 
        where TCommand : EntityCommand<string>
    {
        public DealCommandValidator()
        {

            this.RuleFor(c => c.Title)
                .MinimumLength(MinTitleLength)
                .MaximumLength(MaxTitleLength)
                .NotEmpty();

            this.RuleFor(c => c.ImageUrl)
                .MaximumLength(MaxUrlLength)
                .NotEmpty();

            this.RuleFor(c => c.Description)
                .MinimumLength(MinDescriptionLength)
                .MaximumLength(MaxDescriptionLength)
                .NotEmpty();

            this.RuleFor(c => c.Price)
                .InclusiveBetween(Zero, decimal.MaxValue);


            this.RuleFor(c => c.SellerId)
                .MinimumLength(MinGuidIdLength)
                .MaximumLength(MaxGuidIdLength)
                .NotEmpty();
        }
    }
}
