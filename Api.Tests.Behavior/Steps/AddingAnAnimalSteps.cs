using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps
{
    [Binding]
    public class AddingAnAnimalSteps
    {
        private readonly SafariContext _context;
        private readonly IAnimalService _service;
        private readonly List<Animal> _animals = new(){
            new Animal()
        {
            Id = Guid.NewGuid(),
            Name = "Tony",
            Species = Species.Tiger
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
                Species = Species.Elephant
        }
};

        private Animal animal = new();

        public AddingAnAnimalSteps()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new SafariContext(options);
            _service = new AnimalService(_context);
        }

        [Given(@"administrator is logged in to the system")]
        public void Given1()
        {

        }

        [Given(@"he sees that list of animals")]
        public async void Given2()
        {
            await _context.AddRangeAsync(_animals);
            await _context.SaveChangesAsync();
        }

        [When(@"he gives instruction to go to page for adding animal")]
        public void When1()
        {

        }

        [When(@"he enters information about an animal")]
        public void When2()
        {
            animal = new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Jerry",
                Species = Species.Duck
            };
        }

        [When(@"he gives instruction to add that animal")]
        public async void When3()
        {
            await _service.CreateAnimal(animal);
        }

        [Then(@"the animal will be added to list")]
        public void Then()
        {
            var result = _context.Animals.FirstAsync(x => x.Id == animal.Id);
            Assert.NotNull(result);
        }

    }
}
