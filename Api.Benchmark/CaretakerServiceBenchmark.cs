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
    public class CaretakerServiceBenchmark
    {
        private readonly SafariContext _context;
        private readonly CaretakerService _caretakerService;

        private readonly Caretaker _caretaker;
        private readonly Animal _animal;
        private readonly Guid _guid;
        private readonly Guid _guid2;


        public CaretakerServiceBenchmark()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new SafariContext(options);
            _caretakerService = new CaretakerService(_context);

            _guid = Guid.NewGuid();
            _guid2 = Guid.NewGuid();
            _animal = new Animal
            {
                Id = _guid2,
                Name = "Tony",
                DateOfBirth = DateTime.Now,
                Species = Species.Lion,
                Enclosure = Enclosure.SOUTHERN,
                CaretakerId = Guid.NewGuid()
            };
            _caretaker = new Caretaker
            {
                Id = _guid,
                FirstName = "George",
                LastName = "Washington",
                Animals = new List<Animal>
                {
                    _animal
                }
            };
            
        }

        [Benchmark]
        public void ReadById()
        {
            _caretakerService.ReadById(_guid);
        }

        [Benchmark]
        public void ReadAll()
        {
            _caretakerService.Read();
        }

        [Benchmark]
        public void Create()
        {
            _caretakerService.Create(_caretaker);
        }

        [Benchmark]
        public void Update()
        {

            _caretakerService.Update(_guid, _caretaker);
        }

        [Benchmark]
        public void Delete()
        {
            _caretakerService.Delete(_guid);
        }
    }
}
