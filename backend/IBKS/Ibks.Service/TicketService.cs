using Ibks.Data;
using Ibks.Interfaces;
using Ibks.Models.TicketModels;
using System.Net.Sockets;
using AutoMapper;
using Ibks.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Ibks.Models.Base;

namespace Ibks.Service
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TicketService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<TicketListItemModel>> GetAllAsync(PaginationQuery query)
        {
            int skip = (query.PageNumber - 1) * query.PageSize;
            int totalCount = await _context.Tickets.CountAsync();

            var tickets = await _context.Tickets
                .Include(t => t.Priority)
                .Include(t => t.LogType)
                .Include(t => t.Status)
                .Include(t => t.TicketType)
                .Skip(skip)
                .Take(query.PageSize)
                .ToListAsync();

            var mappedTickets = _mapper.Map<List<TicketListItemModel>>(tickets);

            return new PaginatedResult<TicketListItemModel>
            {
                Items = mappedTickets,
                TotalCount = totalCount,
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
        }

        public async Task<TicketModel> GetByIdAsync(long id)
        {
            var ticket = await _context.Tickets
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.LogType)
                .Include(t => t.TicketType)
                .Include(t => t.Replies) 
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null) return null;

            return _mapper.Map<TicketModel>(ticket);
        }

        public async Task<TicketModel> CreateAsync(TicketModel ticketModel)
        {
            var ticketEntity = _mapper.Map<TicketEntity>(ticketModel);
            var createdEntity = await _context.Tickets.AddAsync(ticketEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TicketModel>(createdEntity.Entity);
        }

        public async Task<TicketModel> UpdateAsync(TicketModel ticketModel)
        {
            var existingTicket = await _context.Tickets.FindAsync(ticketModel.Id);
            if (existingTicket == null) return null;

            _mapper.Map(ticketModel, existingTicket);

            _context.Tickets.Update(existingTicket);
            await _context.SaveChangesAsync();

            return _mapper.Map<TicketModel>(existingTicket);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return false;

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TicketMetadataModel> GetMetadataAsync()
        {
            var urgentLevels = await _context.Priorities
                .Select(u => new MetadataItem { Id = u.Id, Title = u.Title })
                .ToListAsync();

            var types = await _context.TicketTypes
                .Select(t => new MetadataItem { Id = t.Id, Title = t.Title })
                .ToListAsync();

            var states = await _context.Statuses
                .Select(s => new MetadataItem { Id = s.Id, Title = s.Title })
                .ToListAsync();

            return new TicketMetadataModel
            {
                UrgentLevels = urgentLevels,
                Types = types,
                States = states
            };
        }
    }
}
