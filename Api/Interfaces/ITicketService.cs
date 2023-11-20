using Api.DTO;
using Api.Entities;

namespace Api.Interfaces;

public interface ITicketService
{
    Task<ICollection<Ticket>> GetUsersTicketsAsync(Guid userId);
    Task<bool> ReturnUsersTicketAsync(Guid userId, Guid ticketId);
    Task<ICollection<AvailableTicket>> GetAvailableTicketsAsync();
    Task<ICollection<Ticket>> BuyTicketAsync(Guid userId, Ticket ticketId);
}
