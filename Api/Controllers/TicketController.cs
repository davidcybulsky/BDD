﻿using Api.DTO;
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
            return BadRequest();
        }
        return Ok(tickets);
    }

    [HttpPost]
    public async Task<ActionResult<TicketDto>> PurchaseTicket([FromQuery] Guid userId ,[FromBody] TicketDto ticketToBuy)
    {
        var ticket = await _ticketService.BuyTicketAsync(userId, ticketToBuy);
        if(ticket == null)
        {
            return BadRequest();
        }
        return Ok(ticket);
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<ICollection<Ticket>>> GetUsersTickets(Guid userId)
    {
        var tickets = await _ticketService.GetUsersTicketsAsync(userId);
        if(tickets == null)
        {
            return BadRequest();
        }
        return Ok(tickets);
    }

    [HttpDelete("{ticketId}")]
    public async Task<ActionResult<bool>> ReturnUsersTicketAsync([FromQuery] Guid userId, Guid ticketId)
    {
        var result = await _ticketService.ReturnUsersTicketAsync(userId, ticketId);
        if(result == false)
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<TicketDto>>> GetAllTickets()
    {
        var tickets = await _ticketService.GetAllTicketsAsync();
        if (tickets == null)
        {
            return NoContent();
        }
        return Ok(tickets);
    }
}
