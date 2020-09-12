using Seller.Shared.Messages.Offers;

namespace Seller.Notifications.Messages
{
    using System.Threading.Tasks;
    using MassTransit;
    using Microsoft.AspNetCore.SignalR;
    using Hub;
    using static Constants;
    public class ListingCreatedConsumer : IConsumer<ListingCreatedMessage>
    {
        private readonly IHubContext<NotificationsHub> hub;

        public ListingCreatedConsumer(IHubContext<NotificationsHub> hub)
        {
            this.hub = hub;
        }

        public async Task Consume(ConsumeContext<ListingCreatedMessage> context)
        {
            await this.hub.Clients.Group(AuthenticatedUsersGroup).SendAsync(ReceiveNotificationEndPoint, context.Message);
        }
    }
}
