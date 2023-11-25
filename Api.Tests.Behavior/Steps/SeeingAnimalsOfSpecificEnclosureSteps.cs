using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Tests.Behavior.Steps
{
    [Binding]
    public class SeeingAnimalsOfSpecificEnclosureSteps
    {
        private readonly SafariContext _context;
        private readonly IExtendedAnimalService _service;
        private static readonly Enclosure enclosure = Enclosure.NORTHERN;
        private readonly List<Animal> _animals = new(){
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Tony",
                Enclosure = enclosure
            },
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Zoe",
                Enclosure = Enclosure.WESTERN
            },
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Joe",
                Enclosure = Enclosure.EASTERN
            },
            new Animal()
            {
                Id = Guid.NewGuid(),
                Name = "Janusz",
                Enclosure = enclosure
            }   
        };

        private List<Animal> specificAnimals;

        public SeeingAnimalsOfSpecificEnclosureSteps()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new SafariContext(options);
            _service = new AnimalService(_context);
        }

        [Given(@"user sees list of animals")]
        public async void Given()
        {
            await _context.AddRangeAsync(_animals);
            await _context.SaveChangesAsync();
        }

        [When(@"he gives instruction to only see animals of specific enclosure")]
        public async void When()
        {
            specificAnimals = (List<Animal>)(await _service.GetAnimalsByEnclosure(enclosure));
        }

        [Then(@"the list of animals of that enclosure will be displayed")]
        public void Then()
        {
            Assert.True(specificAnimals.All(x => x.Enclosure == enclosure));
        }
    }



}
