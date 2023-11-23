using Api.DTO;
using Api.Entities;
using Api.Interfaces;
using Api.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps;

[Binding]
public class BuyingATicketSteps
{
    private readonly SafariContext _context;
    private readonly ITicketService _ticketService;
    private readonly IUserService _userService;
    private User _user;
    private TicketDto _ticketToBuy;
    private TicketDto _boughtTicketResult;
    private readonly IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));

    public BuyingATicketSteps()
    {
        var options = new DbContextOptionsBuilder<SafariContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _context = new SafariContext(options);
        _ticketService = new TicketService(_context, _mapper);
        _userService = new UserService(_context);
    }
    [Given(@"visitor is logged in")]
    public async void GivenVisitorIsLoggedIn()
    {
        var user = new RegisterUserDto()
        {
            Username = "user",
            Email = "email@gmail.com",
            Password = "pass"
        };
        _user = await _userService.RegisterUser(user);
    }

    [Given(@"there are available tickets")]
    public async void GivenThereAreAvailableTickets()
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
    }


    [When(@"he chooses the ticket he wants to buy")]
    public async void WhenHeChoosesTheTicketHeWantsToBuy()
    {
        var ticketList = await _ticketService.GetAvailableTicketsAsync();
        var choosenTicket = ticketList.First();
        _ticketToBuy = new TicketDto()
        {
            Id = choosenTicket.Id,
            Price = choosenTicket.Price,
            Enclosure = choosenTicket.Enclosure
        };
    }

    [When(@"chooses the date")]
    public void WhenChoosesTheDate()
    {
        _ticketToBuy.Date = DateTime.Now;
    }


    [When(@"he gives instruction to buy the ticket")]
    public async void WhenHeGivesInstructionToBuyTheTicket()
    {
        _boughtTicketResult = await _ticketService.BuyTicketAsync(_user.Id, _ticketToBuy);
    }

    [Then(@"the ticket will be added to his account")]
    public void ThenTheTicketWillBeAddedToHisAccount()
    {
        _boughtTicketResult.Id.Should().NotBe(_ticketToBuy.Id);
        _boughtTicketResult.Price.Should().Be(_ticketToBuy.Price);
        _boughtTicketResult.Date.Should().Be(_ticketToBuy.Date);
        _boughtTicketResult.Enclosure.Should().Be(_ticketToBuy.Enclosure);
    }

}
