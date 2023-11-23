using Api.DTO;
using Api.Entities;
using Api.Interfaces;
using Api.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps;
[Binding]
public class SeeingMyTicketsSteps
{

    private readonly SafariContext _context;
    private readonly ITicketService _ticketService;
    private readonly IUserService _userService;
    private User _user;
    private TicketDto _boughtTicket;
    private List<TicketDto> _ticketsResult;
    private readonly IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));

    public SeeingMyTicketsSteps()
    {
        var options = new DbContextOptionsBuilder<SafariContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _context = new SafariContext(options);
        _ticketService = new TicketService(_context, _mapper);
        _userService = new UserService(_context);
    }

    [Given(@"the visitor is logged in")]
    public async void GivenTheVisitorIsLoggedIn()
    {
        var user = new RegisterUserDto()
        {
            Username = "user",
            Email = "email@gmail.com",
            Password = "pass"
        };
        _user = await _userService.RegisterUser(user);
    }

    [Given(@"visitor bought tickets")]
    public async void GivenVisitorBoughtTickets()
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

        var ticketList = await _ticketService.GetAvailableTicketsAsync();
        var choosenTicket = ticketList.First();
        _boughtTicket = new TicketDto()
        {
            Id = choosenTicket.Id,
            Price = choosenTicket.Price,
            Enclosure = choosenTicket.Enclosure
        };

        _boughtTicket.Date = DateTime.Now;

        _ = await _ticketService.BuyTicketAsync(_user.Id, _boughtTicket);
    }

    [When(@"he gives instruction to see his tickets")]
    public async void WhenHeGivesInstructionToSeeHisTickets()
    {
        _ticketsResult = (List<TicketDto>) await _ticketService.GetUsersTicketsAsync(_user.Id);
    }

    [Then(@"his tickets will be displayed")]
    public void ThenHisTicketsWillBeDisplayed()
    {
        var ticketResult = _ticketsResult.First();
        ticketResult.Id.Should().NotBe(_boughtTicket.Id);
        ticketResult.Price.Should().Be(_boughtTicket.Price);
        ticketResult.Date.Should().Be(_boughtTicket.Date);
        ticketResult.Enclosure.Should().Be(_boughtTicket.Enclosure);
    }

}
