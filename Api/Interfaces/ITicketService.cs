using Api.DTO;
using Api.Entities;

namespace Api.Interfaces;

public interface ITicketService
{
    Task<ICollection<Ticket>> GetUsersTicketsAsync(Guid userId);
    Task<bool> ReturnUsersTicket(Guid userId, Guid ticketId);
    Task<ICollection<AvailableTicket>> GetAvailableTickets();
    Task<ICollection<Ticket>> PurchaseTicket(Guid userId, PurchaseTicketDto ticketId);
}
