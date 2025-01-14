using Ibks.Models.Base;
using Ibks.Models.TicketModels;

namespace Ibks.Interfaces
{
    public interface ITicketService
    {
        Task<PaginatedResult<TicketListItemModel>> GetAllAsync(PaginationQuery query);
        Task<TicketModel> GetByIdAsync(long id);
        Task<TicketModel> CreateAsync(CreateTicketModel ticket);
        Task<TicketModel> UpdateAsync(TicketModel ticket);
        Task<TicketMetadataModel> GetMetadataAsync();
    }
}
