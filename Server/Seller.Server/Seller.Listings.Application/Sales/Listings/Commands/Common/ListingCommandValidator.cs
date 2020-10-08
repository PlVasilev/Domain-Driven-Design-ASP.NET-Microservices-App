using FluentValidation;
using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Sales.Listings.Commands.Common
{
    using static Shared.DDD.Domain.Models.ModelConstants.Common;
    using static Shared.DDD.Domain.Models.ModelConstants.Listing;
    public class ListingCommandValidator<TCommand> : AbstractValidator<ListingCommand<TCommand>> 
        where TCommand : EntityCommand<string>
    {
        public ListingCommandValidator()
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
