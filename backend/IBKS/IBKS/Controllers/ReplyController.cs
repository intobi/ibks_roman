using Ibks.Interfaces;
using Ibks.Models.TicketReplyModels;
using Ibks.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace IBKS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyService _replyService;

        public ReplyController(IReplyService replyService)
        {
            _replyService = replyService;
        }

        [HttpGet("GetByTicketId")]
        [ProducesResponseType(typeof(List<TicketReplyModel>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetByTicketId(long ticketId)
        {
            var result = await _replyService.GetByTicketIdAsync(ticketId);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<TicketReplyModel>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _replyService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("Create")]
        [ProducesResponseType(typeof(TicketReplyModel), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Create(CreateReplyModel reply)
        {
            var result = await _replyService.CreateAsync(reply);
            return Ok(result);
        }

        [HttpPut("Update")]
        [ProducesResponseType(typeof(TicketReplyModel), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Update(TicketReplyModel reply)
        {
            var result = await _replyService.UpdateAsync(reply);
            return Ok(result);
        }
    }
}
