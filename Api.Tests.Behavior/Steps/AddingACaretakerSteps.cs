using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps
{
    [Binding]
    public class AddingACaretakerSteps
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

        public AddingACaretakerSteps()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new SafariContext(options);
            _service = new CaretakerService(_context);
        }

        [Given(@"an administrator is logged in")]
        public void Given()
        {

        }

        [Given(@"he sees a list of that caretakers")]
        public async void Given2()
        {
            await _context.AddRangeAsync(_caretakers);
            await _context.SaveChangesAsync();
        }

        [When(@"he gives instruction to go to page for adding caretaker")]
        public void When()
        {

        }

        [When(@"he enters information about that caretaker")]
        public void When2()
        {
            caretaker = new()
            {
                Id = 5,
                FirstName = "Jan",
                LastName = "Sobol"
            };
        }

        [When(@"he gives instruction to add that caretaker")]
        public void When3()
        {
            _service.Create(caretaker);
        }

        [Then(@"the caretaker will be added to list")]
        public async void Then()
        {
            Assert.NotNull(await _context.Caretakers.FirstAsync(x => x.Id == caretaker.Id));
        }
    }
}
