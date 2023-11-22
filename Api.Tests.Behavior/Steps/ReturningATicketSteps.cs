using Api.DTO;
using Api.Entities;
using Api.Interfaces;
using Api.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps;

[Binding]
public class ReturningATicketSteps
{
    private readonly SafariContext _context;
    private readonly ITicketService _ticketService;
    private readonly IUserService _userService;
    private User _user;
    private List<TicketDto> _userTickets;
    private bool _removingResult;
    private readonly IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));


    public ReturningATicketSteps()
    {
        var options = new DbContextOptionsBuilder<SafariContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _context = new SafariContext(options);
        _ticketService = new TicketService(_context, _mapper);
        _userService = new UserService(_context);
    }

    [Given(@"the visitor is logged")]
    public async void GivenTheVisitorIsLogged()
    {
        var user = new RegisterUserDto()
        {
            Username = "user",
            Email = "email@gmail.com",
            Password = "pass"
        };
        _user = await _userService.RegisterUser(user);
    }

    [Given(@"he sees his tickets")]
    public async void GivenHeSeesHisTickets()
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
        var boughtTicket = new TicketDto()
        {
            Id = choosenTicket.Id,
            Price = choosenTicket.Price,
            Enclosure = choosenTicket.Enclosure
        };

        boughtTicket.Date = DateTime.Now;

        _ = await _ticketService.BuyTicketAsync(_user.Id, boughtTicket);
        _userTickets = (List<TicketDto>) await _ticketService.GetUsersTicketsAsync(_user.Id);
    }

    [When(@"he gives instruction to return some ticket")]
    public async void WhenHeGivesInstructionToReturnSomeTicket()
    {
        _removingResult = await _ticketService.ReturnUsersTicketAsync(_user.Id, _userTickets.First().Id);
    }

    [Then(@"this ticket will be removed from his account")]
    public async void ThenThisTicketWillBeRemovedFromHisAccount()
    {
        var userTickets = (List<TicketDto>) await _ticketService.GetUsersTicketsAsync(_user.Id);

        userTickets.Count.Should().Be(0);
        _removingResult.Should().Be(true);
    }
}
