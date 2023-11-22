
using Api.Entities;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps
{
    [Binding]
    public class SeeingSpecificAnimalSteps
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

        private Animal animal;
        private Guid id;

        public SeeingSpecificAnimalSteps()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new SafariContext(options);
            _service = new AnimalService(_context);
        }

        [Given(@"user sees a list of animals")]
        public async void Given()
        {
            id = _animals[1].Id;
            await _context.AddRangeAsync(_animals);
            await _context.SaveChangesAsync();
        }

        [When(@"he gives instruction to see details of specific animal")]
        public async void When()
        {
            animal = await _service.GetAnimal(id);
        }

        [Then(@"the information about that animal will be displayed")]
        public void Then()
        {
            Assert.NotNull(animal);
            Assert.True(animal.Id == id);
        }
    }
}
