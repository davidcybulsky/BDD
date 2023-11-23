using Api.DTO;
using Api.Entities;
using Api.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class TicketService : ITicketService
{
    private readonly SafariContext _context;
    private readonly IMapper _mapper;
    public TicketService(SafariContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ICollection<AvailableTicket>> GetAvailableTicketsAsync()
    {
        return await _context.AvailableTickets.ToListAsync();
    }

    public async Task<ICollection<TicketDto>> GetUsersTicketsAsync(Guid userId)
    {
        var user = await _context.Users.Where(u => u.Id == userId).Include(u => u.Tickets).FirstOrDefaultAsync();

        if (user is null)
        {
            return null;
        }

        return user.Tickets.Select(t => _mapper.Map<TicketDto>(t)).ToList();
    }

    public async Task<TicketDto> BuyTicketAsync(Guid userId, TicketDto ticket)
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

        return _mapper.Map<TicketDto>(boughtTicket);
    }

    public async Task<bool> ReturnUsersTicketAsync(Guid userId, Guid ticketId)
    {
        var user = await _context.Users.Where(u => u.Id == userId).Include(u => u.Tickets).FirstOrDefaultAsync();

        if(user is null)
        {
            return false;
        }

        var ticket = await _context.Tickets.Where(t => t.Id == ticketId).FirstOrDefaultAsync();

        if(ticket is null)
        {
            return false;
        }
        
        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();
        
        return true;
    }
    public async Task<ICollection<Ticket>> GetAllTicketsAsync()
    {
        var tickets = await _context.Tickets.ToListAsync();

        if (tickets is null)
        {
            return null;
        }

        return tickets;
    }
}
