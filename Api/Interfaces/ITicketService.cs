using Api.DTO;
using Api.Entities;

namespace Api.Interfaces;

public interface ITicketService
{
    Task<ICollection<TicketDto>> GetUsersTicketsAsync(Guid userId);
    Task<bool> ReturnUsersTicketAsync(Guid userId, Guid ticketId);
    Task<ICollection<AvailableTicket>> GetAvailableTicketsAsync();
    Task<TicketDto> BuyTicketAsync(Guid userId, TicketDto ticketId);
    Task<ICollection<Ticket>> GetAllTicketsAsync();

}
