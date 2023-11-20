using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps;

[Binding]
public class SeeingAvailableTicketsSteps
{
    private readonly SafariContext _context;
    private readonly ITicketService _ticketService;
    private List<AvailableTicket> _availableTicketsResult;
    private List<AvailableTicket> _availableTickets;

    public SeeingAvailableTicketsSteps()
    {
        var options = new DbContextOptionsBuilder<SafariContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _context = new SafariContext(options);
        _ticketService = new TicketService(_context);
    }

    [Given(@"the visitor is logged in")]
    public void GivenTheVisitorIsLoggedIn()
    {

    }

    [Given(@"tickets are in db")]
    public async void GivenTicketsAreInDb()
    {
        await _context.AvailableTickets.AddRangeAsync(new AvailableTicket()
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
                });
        await _context.SaveChangesAsync();
        _availableTickets = await _context.AvailableTickets.ToListAsync();
    }


    [When(@"he wants to see available tickets")]
    public async void WhenHeWantsToSeeAvailableTickets()
    {
        _availableTicketsResult = (List<AvailableTicket>) await _ticketService.GetAvailableTickets();
    }

    [Then(@"he can see the details of each ticket")]
    public void ThenHeCanSeeTheDetailsOfEachTicket()
    {
        _availableTicketsResult.Count.Should().Be(_availableTickets.Count);
    }

}
