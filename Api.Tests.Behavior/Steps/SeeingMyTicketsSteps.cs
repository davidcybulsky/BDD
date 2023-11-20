using Api.DTO;
using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps;
public class SeeingMyTicketsSteps
{

    private readonly SafariContext _context;
    private readonly ITicketService _ticketService;
    private readonly IUserService _userService;
    private User _user;
    private List<AvailableTicket> _availableTicketsResult;
    private List<AvailableTicket> _availableTickets;

    public SeeingMyTicketsSteps()
    {
        var options = new DbContextOptionsBuilder<SafariContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _context = new SafariContext(options);
        _ticketService = new TicketService(_context);
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
    public void GivenVisitorBoughtTickets()
    {
    }

    [When(@"he gives instruction to see his tickets")]
    public void WhenHeGivesInstructionToSeeHisTickets()
    {
        throw new PendingStepException();
    }

    [Then(@"his tickets will be displayed")]
    public void ThenHisTicketsWillBeDisplayed()
    {
        throw new PendingStepException();
    }

}
