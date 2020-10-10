using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seller.Listings.Application.Listings.UserSellers.Common;
using Seller.Listings.Domain.Listings.Factories;

namespace Seller.Listings.Application.Listings.UserSellers.Commands.Create
{
    public class CreateUserSellerCommand : UserSellerCommand<CreateUserSellerCommand>, IRequest<bool>
    {
        public class CreateUserSellerHandler : IRequestHandler<CreateUserSellerCommand, bool>
        {
            private readonly IUserSellerRepository sellerRepository;
            private readonly IUserSellerFactory sellerFactory;

            public CreateUserSellerHandler(
                IUserSellerRepository sellerRepository,
                IUserSellerFactory sellerFactory)
            {
                this.sellerRepository = sellerRepository;
                this.sellerFactory = sellerFactory;
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
                        .WithUserId(request.UserId)
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
