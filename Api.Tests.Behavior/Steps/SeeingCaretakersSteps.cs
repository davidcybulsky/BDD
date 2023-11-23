using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps
{
    [Binding]
    public class SeeingCaretakersSteps
    {
        private readonly SafariContext _context;
        private readonly ICaretakerService _service;
        private readonly List<Caretaker> _caretakers = new()
        {
            new Caretaker()
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski"
            },
            new Caretaker()
            {
                Id = 2,
                FirstName = "Damian",
                LastName = "Dziekan"
            },
            new Caretaker()
            {
                Id = 3,
                FirstName = "Piotr",
                LastName = "Nowak"
            },
            new Caretaker()
            {
                Id = 4,
                FirstName = "Zbigniew",
                LastName = "Kowal"
            }
        };

        private IList<Caretaker> caretakers;

        public SeeingCaretakersSteps()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new SafariContext(options);
            _service = new CaretakerService(_context);
        }

        [Given(@"user is on the site")]
        public async void Given()
        {
            await _context.AddRangeAsync(_caretakers);
            await _context.SaveChangesAsync();
        }

        [When(@"he gives instruction to see caretakers")]
        public async void When()
        {
            caretakers = (List<Caretaker>)await _service.Read();
        }

        [Then(@"caretakers will be displayed")]
        public void Then()
        {
            Assert.Equal(_caretakers.Count, caretakers.Count);
        }
    }
}
