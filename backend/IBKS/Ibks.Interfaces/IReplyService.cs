using Ibks.Models.Base;
using Ibks.Models.TicketModels;
using Ibks.Models.TicketReplyModels;

namespace Ibks.Interfaces
{
    public interface IReplyService
    {
        Task<List<ReplyModel>> GetByTicketIdAsync(long ticketId);
        Task<TicketReplyModel> CreateAsync(CreateReplyModel replyModel);
        Task<TicketReplyModel> UpdateAsync(TicketReplyModel reply);
        Task<List<ReplyModel>> GetAllAsync();
    }
}
