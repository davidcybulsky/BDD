using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps
{
    [Binding]
    public class UpdatingAnAnimalSteps
    {
        private readonly SafariContext _context;
        private readonly IAnimalService _animalService;
        private Animal animal;
        private Guid animalId;
        private List<Animal> animals = new(){
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Tony"
            },
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Zoe"
            },
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Joe"
            },
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Janusz"
            }
            };

        public UpdatingAnAnimalSteps()
        {
            var options =
                new DbContextOptionsBuilder<SafariContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new SafariContext(options);
            _animalService = new AnimalService(_context);
        }

        [Given(@"administrator is loggedin")]
        public void Given1()
        {

        }

        [Given(@"he sees a list of all animals")]
        public async void Given2()
        {
            await _context.AddRangeAsync(animals);
            await _context.SaveChangesAsync();
            animalId = (await _context.Animals.FirstAsync()).Id;
        }

        [When(@"he gives instruction to go to page for updating animal")]
        public void When1()
        {

        }

        [When(@"he enters information about that animal")]
        public void When2()
        {
            animal = new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Josh"
            };
        }

        [When(@"he gives instruction to update that animal")]
        public async void When3()
        {
            await _animalService.UpdateAnimal(animalId, animal);
        }

        [Then(@"the animal will be updated")]
        public async void Then()
        {
            Assert.Equal(animal.Name, (await _context.Animals.FirstAsync(x => x.Id == animalId)).Name);
        }

    }
}
