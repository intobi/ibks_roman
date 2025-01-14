using Ibks.Interfaces;
using Ibks.Models.Base;
using Ibks.Models.TicketModels;
using Microsoft.AspNetCore.Mvc;

namespace IBKS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("GetAll")]
        [ProducesResponseType(typeof(PaginatedResult<TicketListItemModel>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetAll(PaginationQuery query)
        {
            var tickets = await _ticketService.GetAllAsync(query);
            return Ok(tickets);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(typeof(TicketModel), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _ticketService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("Create")]
        [ProducesResponseType(typeof(ResultMessage), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Create(TicketModel ticket)
        {
            var result = await _ticketService.CreateAsync(ticket);
            return Ok(result);
        }

        [HttpPut("Update")]
        [ProducesResponseType(typeof(ResultMessage), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Update(TicketModel ticket)
        {
            var result = await _ticketService.UpdateAsync(ticket);
            return Ok(result);
        }

        [HttpGet("GetMetadata")]
        [ProducesResponseType(typeof(TicketMetadataModel), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetMetadata()
        {
            var result = await _ticketService.GetMetadataAsync();
            return Ok(result);
        }
    }
}
