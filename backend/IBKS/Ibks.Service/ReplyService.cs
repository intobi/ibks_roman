using AutoMapper;
using Ibks.Data;
using Ibks.Data.Entities;
using Ibks.Interfaces;
using Ibks.Models.Base;
using Ibks.Models.TicketReplyModels;
using Microsoft.EntityFrameworkCore;

namespace Ibks.Service
{
    public class ReplyService : IReplyService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ReplyService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ReplyModel>> GetByTicketIdAsync(long ticketId)
        {
            var replies = await _context.TicketReplies
                .Where(r => r.Tid == ticketId)
                .ToListAsync();

            return _mapper.Map<List<ReplyModel>>(replies);
        }

        public async Task<TicketReplyModel> CreateAsync(CreateReplyModel replyModel)
        {
            var replyEntity = _mapper.Map<TicketReplyEntity>(replyModel);

            var createdEntity = await _context.TicketReplies.AddAsync(replyEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<TicketReplyModel>(createdEntity.Entity);
        }

        public async Task<TicketReplyModel> UpdateAsync(TicketReplyModel replyModel)
        {
            var existingReply = await _context.TicketReplies.FindAsync(replyModel.ReplyId);
            if (existingReply == null)
            {
                throw new KeyNotFoundException("Reply not found.");
            }

            _mapper.Map(replyModel, existingReply);

            _context.TicketReplies.Update(existingReply);
            await _context.SaveChangesAsync();

            return _mapper.Map<TicketReplyModel>(existingReply);
        }

        public async Task<List<ReplyModel>> GetAllAsync()
        {
            var replies = await _context.TicketReplies.ToListAsync();
            return _mapper.Map<List<ReplyModel>>(replies);
        }
    }
}
