using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Listings.Application.Listings.UserSellers.Common;
using Seller.Listings.Domain.Listings.Factories;
using Seller.Shared.Services.Identity;

namespace Seller.Listings.Application.Listings.UserSellers.Commands.Create
{
    public class CreateUserSellerCommand : UserSellerCommand<CreateUserSellerCommand>, IRequest<bool>
    {
        public class CreateUserSellerHandler : IRequestHandler<CreateUserSellerCommand, bool>
        {
            private readonly IUserSellerRepository sellerRepository;
            private readonly IUserSellerFactory sellerFactory;
            private readonly ICurrentUserService currentUserService;

            public CreateUserSellerHandler(
                IUserSellerRepository sellerRepository,
                IUserSellerFactory sellerFactory,
                ICurrentUserService currentUserService)
            {
                this.sellerRepository = sellerRepository;
                this.sellerFactory = sellerFactory;
                this.currentUserService = currentUserService;
            }

            public async Task<bool> Handle(
                CreateUserSellerCommand request,
                CancellationToken cancellationToken)
            {
                var seller = this.sellerFactory
                        .WithUserName(request.UserName)
                        .WithFirstName(request.FirstName)
                        .WithLastName(request.LastName)
                        .WithEmail(request.Email)
                        .WithPhoneNumber(request.PhoneNumber)
                        .WithUserId(currentUserService.UserId)
                        .Build();

                   await this.sellerRepository.Save(seller, cancellationToken);
                    if (seller.Id == null)
                    {
                        return false;
                    }
                    return true;
            }
        }
    }
}
