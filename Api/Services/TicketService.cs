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

    public async Task<ICollection<AvailableTicket>> GetAvailableTicketsAsync()
    {
        return await _context.AvailableTickets.ToListAsync();
    }

    public async Task<ICollection<Ticket>> GetUsersTicketsAsync(Guid userId)
    {
        var user = await _context.Users.Where(u => u.Id == userId).Include(u => u.Tickets).FirstOrDefaultAsync();
        return user.Tickets.ToList();
    }

    public async Task<Ticket> BuyTicketAsync(Guid userId, Ticket ticket)
    {
        var boughtTicket = new Ticket()
        {
            Id = Guid.NewGuid(),
            Date = ticket.Date,
            Price = ticket.Price,
            Enclosure = ticket.Enclosure,
            UserId = userId
        };

        await _context.Tickets.AddAsync(boughtTicket);
        await _context.SaveChangesAsync();

        return boughtTicket;
    }

    public async Task<bool> ReturnUsersTicketAsync(Guid userId, Guid ticketId)
    {
        var ticket = await _context.Tickets.Where(t => t.Id == ticketId).FirstOrDefaultAsync();
        
        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();
        
        return true;
    }
}
