using System.Text.Json.Serialization;

namespace Api.Entities;

public class Ticket
{
    public Guid Id { get; set; }
    public double Price { get; set; }
    public DateTime Date { get; set; }
    public Enclosure Enclosure { get; set; }
    public Guid UserId { get; set; }
    [JsonIgnore]
    public virtual User user { get; set; }
}
