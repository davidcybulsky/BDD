using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps
{
    [Binding]
    public class UpdatingACaretakerSteps
    {
        private readonly SafariContext _context;
        private readonly ICaretakerService _service;
        private readonly List<Caretaker> _caretakers = new()
        {
            new Caretaker()
            {
                Id = Guid.NewGuid(),
                FirstName = "Jan",
                LastName = "Kowalski"
            },
            new Caretaker()
            {
                Id = Guid.NewGuid(),
                FirstName = "Damian",
                LastName = "Dziekan"
            },
            new Caretaker()
            {
                Id = Guid.NewGuid(),
                FirstName = "Piotr",
                LastName = "Nowak"
            },
            new Caretaker()
            {
                Id = Guid.NewGuid(),
                FirstName = "Zbigniew",
                LastName = "Kowal"
            }
        };

        private Caretaker caretaker;

        public UpdatingACaretakerSteps()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new SafariContext(options);
            _service = new CaretakerService(_context);
        }

        [Given(@"the administrator is logged in")]
        public void Given()
        {

        }

        [Given(@"he sees the list of that caretakers")]
        public async void Given2()
        {
            await _context.AddRangeAsync(_caretakers);
            await _context.SaveChangesAsync();
        }

        [When(@"he gives instruction to go to page for updating caretaker")]
        public void When()
        {

        }

        [When(@"he enters some information about that caretaker")]
        public void When2()
        {
            caretaker = new()
            {
                FirstName = "Jacek",
                LastName = "Jaworek"
            };
        }

        [When(@"he gives instruction to update that caretaker")]
        public void When3()
        {
            _service.Update(_caretakers[1].Id, caretaker);
        }

        [Then(@"the caretaker will be updated")]
        public async void Then()
        {
            var result = await _context.Caretakers.FirstAsync(x => x.Id == _caretakers[1].Id);
            Assert.Equal(caretaker.FirstName + caretaker.LastName, result.FirstName + result.LastName);
        }
    }
}
