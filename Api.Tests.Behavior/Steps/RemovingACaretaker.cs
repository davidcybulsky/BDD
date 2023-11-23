using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps
{
    [Binding]
    public class RemovingACaretaker
    {
        private readonly SafariContext _context;
        private readonly ICaretakerService _service;
        private static int caretakerId = 1;
        private readonly List<Caretaker> _caretakers = new()
        {
            new Caretaker()
            {
                Id = caretakerId,
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

        public RemovingACaretaker()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new SafariContext(options);
            _service = new CaretakerService(_context);
        }

        [Given(@"administrator is logged into the system")]
        public void Given()
        {

        }

        [Given(@"he sees a list of caretakers")]
        public async void Given2()
        {
            await _context.AddRangeAsync(_caretakers);
            await _context.SaveChangesAsync();
        }

        [When(@"he gives instruction to remove specific caretaker")]
        public void When()
        {
            _service.Delete(caretakerId);
        }

        [When(@"he agrees that he is sure he wants it to do")]
        public void When2()
        {

        }

        [Then(@"the caretaker will be removed from the list")]
        public async void Then()
        {
            Assert.Null(await _context.Caretakers.FirstOrDefaultAsync(x => x.Id == caretakerId));
        }
    }
}
