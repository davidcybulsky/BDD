using Api.DTO;
using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet("availableTickets")]
    public async Task<ActionResult<ICollection<AvailableTicket>>> GetAvailableTickets()
    {
        var tickets = await _ticketService.GetAvailableTicketsAsync();
        if(tickets == null)
        {
            return NotFound();
        }
        return Ok(tickets);
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Ticket>>> PurchaseTicket([FromQuery] Guid userId ,[FromBody] Ticket ticketToBuy)
    {
        var tickets = await _ticketService.BuyTicketAsync(userId, ticketToBuy);
        if(tickets == null)
        {
            return NotFound();
        }
        return Ok(tickets);
    }
}
