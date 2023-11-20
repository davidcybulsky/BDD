using Api.DTO;
using Api.Entities;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class TicketService : ITicketService
{
    private readonly SafariContext _context;
    public TicketService(SafariContext context)
    {
        _context = context;
    }

    public async Task<ICollection<AvailableTicket>> GetAvailableTickets()
    {
        return await _context.AvailableTickets.ToListAsync();
    }

    public Task<ICollection<Ticket>> GetUsersTicketsAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Ticket>> PurchaseTicket(Guid userId, PurchaseTicketDto ticketId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ReturnUsersTicket(Guid userId, Guid ticketId)
    {
        throw new NotImplementedException();
    }
}
