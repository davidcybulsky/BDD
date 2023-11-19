namespace Api.Entities;

public class Ticket
{
    public Guid Id { get; set; }
    public double Price { get; set; }
    public DateTime Date { get; set; }
    public Enclosure Enclosure { get; set; }
    //skoro ticket ma uniwersalne id i date to nie powinno być
    //many to many że dany ticket ma x userów imo.
}
