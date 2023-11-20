using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps
{
    [Binding]
    public class RemovingAnAnimalSteps
    {
        private readonly SafariContext _context;
        private readonly IAnimalService _animalService;
        private Animal animal;
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

        public RemovingAnAnimalSteps()
        {
            var options =
                new DbContextOptionsBuilder<SafariContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new SafariContext(options);
            _animalService = new AnimalService(_context);
        }

        [Given(@"administrator is logged in")]
        public void GivenAdministratorIsLoggedIn()
        {

        }

        [Given(@"he sees a list of animals")]
        public async void GivenHeSeesAListOfAnimals()
        {
            await _context.AddRangeAsync(animals);
            await _context.SaveChangesAsync();
            animal = await _context.Animals.FirstAsync();
        }

        [When(@"he gives instruction to remove specific animal")]
        public async void WhenHeGivesInstructionToRemoveSpecificAnimal()
        {
            await _animalService.DeleteAnimal(animal.Id);
        }

        [When(@"he agrees that he is sure he wants to do it")]
        public void WhenHeAgreesThatHeIsSureHeWantsToDoIt()
        {

        }

        [Then(@"the animal will be removed from the list")]
        public async void ThenTheAnimalWillBeRemovedFromTheList()
        {
            animals = await _context.Animals.ToListAsync();
            Assert.Null(animals.FirstOrDefault(x => x.Id == animal.Id));
        }
    }
}
