using FluentValidation;
using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Sales.UserSellers.Common
{
    using static Shared.DDD.Domain.Models.ModelConstants.Common;
    using static Shared.DDD.Domain.Models.ModelConstants.UserSeller;
    public class UserSellerCommandValidator<TCommand> : AbstractValidator<UserSellerCommand<TCommand>> 
        where TCommand : EntityCommand<string>
    {
        public UserSellerCommandValidator()
        {

            this.RuleFor(u => u.UserName )
                .MinimumLength(MinUserNameLength)
                .MaximumLength(MaxUserNameLength)
                .NotEmpty();

            this.RuleFor(u => u.FirstName)
                .MinimumLength(MinUserNameLength)
                .MaximumLength(MaxUserNameLength)
                .NotEmpty();

            this.RuleFor(u => u.LastName)
                .MinimumLength(MinUserNameLength)
                .MaximumLength(MaxUserNameLength)
                .NotEmpty();

            this.RuleFor(c => c.Email)
                .Matches(EmailRegex)
                .NotEmpty();

            this.RuleFor(c => c.PhoneNumber)
                .Matches(PhoneRegex)
                .NotEmpty();

            this.RuleFor(c => c.UserId)
                .MinimumLength(MinGuidIdLength)
                .MaximumLength(MaxGuidIdLength)
                .NotEmpty();
        }
    }
}
