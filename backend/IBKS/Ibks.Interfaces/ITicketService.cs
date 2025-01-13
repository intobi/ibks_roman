using Ibks.Models.Base;
using Ibks.Models.TicketModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ibks.Interfaces
{
    public interface ITicketService
    {
        Task<PaginatedResult<TicketListItemModel>> GetAllAsync(PaginationQuery query);
        Task<TicketModel> GetByIdAsync(long id);
        Task<TicketModel> CreateAsync(TicketModel ticket);
        Task<TicketModel> UpdateAsync(TicketModel ticket);
        Task<bool> DeleteAsync(long id);
    }
}
