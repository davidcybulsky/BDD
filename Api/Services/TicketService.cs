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

    public Task<ICollection<Ticket>> GetUsersTicketsAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Ticket>> BuyTicketAsync(Guid userId, Ticket ticket)
    {
        await _context.Tickets.AddAsync(new Ticket()
        {
            Id = Guid.NewGuid(),
            Date = ticket.Date,
            Price = ticket.Price,
            Enclosure = ticket.Enclosure,
            UserId = userId
        });

        await _context.SaveChangesAsync();

        var user = await _context.Users.Where(u => u.Id == userId).Include(u => u.Tickets).FirstOrDefaultAsync();

        return user.Tickets.ToList();
    }

    public Task<bool> ReturnUsersTicketAsync(Guid userId, Guid ticketId)
    {
        throw new NotImplementedException();
    }
}
