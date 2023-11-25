using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;

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
        //modelBuilder.Entity<Animal>()
        //   .HasOne(a => a.Caretaker)
        //   .WithMany(c => c.Animals)
        //   .HasForeignKey(a => a.CaretakerId);

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

        var caretaker1Id = Guid.NewGuid();
        var caretaker2Id = Guid.NewGuid();
        var caretaker1 = new Caretaker()
        {
            Id = caretaker1Id,
            FirstName = "Albert",
            LastName = "Szybkipuls",
        };
        var caretaker2 = new Caretaker()
        {
            Id = caretaker2Id,
            FirstName = "Norbert",
            LastName = "Firanka",
        };
        var caretakers = new List<Caretaker>() { caretaker1, caretaker2 };

        modelBuilder.Entity<Caretaker>().HasData(caretakers);

        modelBuilder.Entity<Animal>().
            HasData(
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Tony",
                DateOfBirth = DateTime.Now,
                Species = Species.Lion,
                Enclosure = Enclosure.SOUTHERN,
                CaretakerId = caretaker1Id
            },
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Zoe",
                DateOfBirth = DateTime.Now,
                Species = Species.Elephant,
                Enclosure = Enclosure.WESTERN,
                CaretakerId = caretaker1Id
            },
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Joe",
                DateOfBirth = DateTime.Now,
                Species = Species.Zebra,
                Enclosure = Enclosure.NORTHERN,
                CaretakerId = caretaker2Id
            },
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Janusz",
                DateOfBirth = DateTime.Now,
                Species = Species.Duck,
                Enclosure = Enclosure.NORTHERN,
                CaretakerId = caretaker2Id
            }
        );

        var user1Id = Guid.NewGuid();
        var user2Id = Guid.NewGuid();
        var user1 = new User()
        {
            Id = user1Id,
            Username = "skunksior",
            Email = "skunks@skunks.com",
            Password = "haslo123",
            IsAdmin = false
        };
        var user2 = new User()
        {
            Id = user2Id,
            Username = "czadoman",
            Email = "czad@man.com",
            Password = "password",
            IsAdmin = true
        };
        var users = new List<User>() { user1, user2 };

        modelBuilder.Entity<User>().HasData(users);

        modelBuilder.Entity<Ticket>().HasData(
            new Ticket()
            {
                Id = Guid.NewGuid(),
                Price = 14.50,
                Date = DateTime.Now,
                Enclosure = Enclosure.SOUTHERN,
                UserId = user1Id
            },
            new Ticket()
            {
                Id = Guid.NewGuid(),
                Price = 16.50,
                Date = DateTime.Now,
                Enclosure = Enclosure.EASTERN,
                UserId = user1Id
            },
            new Ticket()
            {
                Id = Guid.NewGuid(),
                Price = 17.50,
                Date = DateTime.Now,
                Enclosure = Enclosure.WESTERN,
                UserId = user2Id
            }
        );
         
    }
}
