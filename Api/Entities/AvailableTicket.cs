namespace Api.Entities;

public class AvailableTicket
{
    public Guid Id { get; set; }
    public double Price { get; set; }
    public Enclosure Enclosure { get; set; }
}
