using Api.Entities;
using Api.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps
{
    [Binding]
    public class SeeingAllTIcketsOfAllVisitorsSteps
    {
        private readonly SafariContext _context;
        private readonly TicketService _service;
        private readonly IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));

        public SeeingAllTIcketsOfAllVisitorsSteps()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new SafariContext(options);
            _service = new TicketService(_context, _mapper);
        }

        private static readonly Guid _guid = Guid.NewGuid();

        private readonly User _user = new()
        {
            Id = _guid,
            Email = "",
            Password = "",
            IsAdmin = true,
            Username = ""
        };

        private readonly IEnumerable<Ticket> _tickets = new List<Ticket>()
        {
            new Ticket()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Enclosure = Enclosure.EASTERN,
                UserId = _guid,
                Price = 10,
            },             new Ticket()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Enclosure = Enclosure.SOUTHERN,
                UserId = _guid,
                Price = 108,
            },
                        new Ticket()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Enclosure = Enclosure.WESTERN,
                UserId = _guid,
                Price = 160,
            }
        };

        private IEnumerable<Ticket> ticketsInDb = null;

        [Given(@"administrator is on site")]
        public async void Given()
        {
            await _context.AddAsync(_user);
            await _context.SaveChangesAsync();
            await _context.AddRangeAsync(_tickets);
            await _context.SaveChangesAsync();
        }

        [When(@"he gives instruction to only see all tickets of all visitors")]
        public async void When()
        {
            ticketsInDb = await _service.GetAllTicketsAsync();
            var count = _context.Tickets.Count();
        }

        [Then(@"the list of all tickets of all visitors will be displayed")]
        public void Then()
        {
            Assert.Equal(_tickets.Count(), ticketsInDb.Count());
        }
    }
}
