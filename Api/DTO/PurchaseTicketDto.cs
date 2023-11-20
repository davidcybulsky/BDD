using Api.Entities;

namespace Api.DTO;

public class PurchaseTicketDto
{
    public double Price { get; set; }
    public DateTime Date { get; set; }
    public Enclosure Enclosure { get; set; }
}
