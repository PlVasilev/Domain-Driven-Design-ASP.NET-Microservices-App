using Seller.Shared.DDD.Application;

namespace Seller.Listings.Application.Sales.UserSellers.Common
{
    
    public abstract class UserSellerCommand<TCommand> : EntityCommand<string>
        where TCommand : EntityCommand<string>
    {
        public string UserName { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string UserId { get; set; } = default!;
        
    }
}
