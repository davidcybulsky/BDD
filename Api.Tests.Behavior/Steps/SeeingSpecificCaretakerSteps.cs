using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps
{
    [Binding]
    public class SeeingSpecificCaretakerSteps
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

        private Caretaker caretaker;

        public SeeingSpecificCaretakerSteps()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new SafariContext(options);
            _service = new CaretakerService(_context);
        }

        [Given(@"user sees list of caretakers")]
        public async void Given()
        {
            await _context.AddRangeAsync(_caretakers);
            await _context.SaveChangesAsync();
        }

        [When(@"he gives instruction to see which animals are taken care of by this caretaker")]
        public async void When()
        {
            caretaker = await _service.ReadById(_caretakers[1].Id);
        }

        [Then(@"the information about that caretaker will be displayed")]
        public void Then()
        {
            Assert.NotNull(caretaker);
            Assert.Equal(caretaker.Id, _caretakers[1].Id);
        }
    }
}
