using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Api.Entities;
using Api.Services;
using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Api.Benchmark
{
    public class AnimalServiceBenchmark
    {
        private readonly SafariContext _context;
        private readonly AnimalService _animalService;

        private readonly Animal _animal;
        private readonly Guid _guid;

        public AnimalServiceBenchmark()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new SafariContext(options);
            _animalService = new AnimalService(_context);

            _guid = Guid.NewGuid();
            _animal = new Animal
            {
                Id = _guid,
                Name = "Tony",
                DateOfBirth = DateTime.Now,
                Species = Species.Lion,
                Enclosure = Enclosure.SOUTHERN,
                CaretakerId = Guid.NewGuid()
            };
        }

        [Benchmark]
        public void GetAnimal()
        {
            _animalService.GetAnimal(_guid);
        }

        [Benchmark]
        public void GetAnimals()
        {
            _animalService.GetAnimals();
        }

        [Benchmark]
        public void CreateAnimal()
        {
            _animalService.CreateAnimal(_animal);
        }

        [Benchmark]
        public void UpdateAnimal()
        {
            
            _animalService.UpdateAnimal(_guid, _animal);
        }

        [Benchmark]
        public void DeleteAnimal()
        {
            _animalService.DeleteAnimal(_guid);
        }

        [Benchmark]
        public void GetAnimalsBySpecies()
        {
            _animalService.GetAnimalsBySpecies(Species.Lion);
        }

        [Benchmark]
        public void GetAnimalsByCaretakerId()
        {
            _animalService.GetAnimalsByCaretakerId(_guid);
        }

        [Benchmark]
        public void GetAnimalsByEnclosure()
        {
            _animalService.GetAnimalsByEnclosure(Enclosure.NORTHERN);
        }



    }
}
