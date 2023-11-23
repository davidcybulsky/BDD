using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps
{
    [Binding]
    public class SeeingAnimalOfSpecificSpecies
    {
        private readonly SafariContext _context;
        private readonly IExtendedAnimalService _service;
        private static readonly Species species = Species.Lion;
        private readonly List<Animal> _animals = new(){
            new Animal()
        {
            Id = Guid.NewGuid(),
            Name = "Tony",
            Species = species
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
                Species = species
        }
        };

        private List<Animal> specificAnimals;

        public SeeingAnimalOfSpecificSpecies()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new SafariContext(options);
            _service = new AnimalService(_context);
        }

        [Given(@"user sees list of species")]
        public async void Given()
        {
            await _context.AddRangeAsync(_animals);
            await _context.SaveChangesAsync();
        }

        [When(@"he gives instruction to see animals of specific species")]
        public async void When()
        {
            specificAnimals = (List<Animal>)(await _service.GetAnimalsBySpecies(species));
        }

        [Then(@"the list of animals of that species will be dislpayed")]
        public void Then()
        {
            Assert.True(specificAnimals.All(x => x.Species == species));
        }
    }
}
