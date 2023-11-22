using Api.Entities;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps
{
    [Binding]
    public class SeeingAnimalsSteps
    {
        private readonly SafariContext _context;
        private readonly AnimalService _service;
        private List<Animal> _animals = new(){
            new Animal()
        {
            Id = Guid.NewGuid(),
            Name = "Tony",
            Species = Species.Elephant
        },
            new Animal()
        {
            Id = Guid.NewGuid(),
                Name = "Zoe",
                Species = Species.Zebra
            },
            new Animal()
        {
            Id = Guid.NewGuid(),
                Name = "Joe",
                Species = Species.Duck
            },
            new Animal()
        {
            Id = Guid.NewGuid(),
                Name = "Janusz",
                Species = Species.Lion
        }
        };

        private List<Animal> animals;

        public SeeingAnimalsSteps()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new SafariContext(options);
            _service = new AnimalService(_context);
        }

        [Given(@"user is on site")]
        public async void Given()
        {
            await _context.AddRangeAsync(_animals);
            await _context.SaveChangesAsync();
        }

        [When(@"he gives instruction to see animals")]
        public async void When()
        {
            animals = (List<Animal>)await _service.GetAnimals();
        }

        [Then(@"animals will be displayed")]
        public void Then()
        {
            Assert.Equal(_animals.Count, animals.Count);
        }
    }
}
