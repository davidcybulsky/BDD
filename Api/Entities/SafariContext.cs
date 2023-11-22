using Microsoft.EntityFrameworkCore;

namespace Api.Entities;

public class SafariContext : DbContext
{
    public DbSet<Animal> Animals { get; set; }

    public DbSet<Caretaker> Caretakers { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Ticket> Tickets { get; set; }

    public DbSet<AvailableTicket> AvailableTickets { get; set; }

    public SafariContext(DbContextOptions<SafariContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AvailableTicket>().HasData(
            new AvailableTicket()
            {
                Id = Guid.NewGuid(),
                Price = 1500,
                Enclosure = Enclosure.NORTHERN
            },
            new AvailableTicket()
            {
                Id = Guid.NewGuid(),
                Price = 2400,
                Enclosure = Enclosure.SOUTHERN
            },
            new AvailableTicket()
            {
                Id = Guid.NewGuid(),
                Price = 1200,
                Enclosure = Enclosure.EASTERN
            },
            new AvailableTicket()
            {
                Id = Guid.NewGuid(),
                Price = 3000,
                Enclosure = Enclosure.WESTERN
            }
        );

        modelBuilder.Entity<Animal>().
            HasData(
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Tony",
                Species = Species.Lion
            },
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Zoe",
                Species = Species.Zebra
            },
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Joe",
                Species = Species.Duck
            },
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Janusz",
                Species = Species.Lion
            });
    }
}
