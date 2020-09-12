using System.Collections.Generic;
using System.Threading.Tasks;
using Seller.Messages.Features.Message.Models;

namespace Seller.Messages.Features.Message.Services.Interfaces
{
    public interface IMessageService
    {
        Task<List<MessageResponseModel>> All();
        Task<bool> Process(string id);
        Task<bool> Add(string senderId, string SenderUsername, string title, string content);
    }
}
