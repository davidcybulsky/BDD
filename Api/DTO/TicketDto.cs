using Api.Entities;

namespace Api.DTO;

public class TicketDto
{
    public Guid Id { get; set; }
    public double Price { get; set; }
    public DateTime Date { get; set; }
    public Enclosure Enclosure { get; set; }
}
