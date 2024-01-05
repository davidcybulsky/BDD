using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Api.Entities;
using Api.Services;
using Api.DTO;
using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Api.Benchmark
{
    public class TicketServiceBenchmark
    {
        private readonly SafariContext _context;
        private readonly TicketService _ticketService;
        private readonly IMapper _mapper;

        private readonly TicketDto _ticketDto;
        private readonly Guid _guid;
        private readonly Guid _guid2;

        public TicketServiceBenchmark()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new SafariContext(options);
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
            _ticketService = new TicketService(_context, _mapper);

            _guid = Guid.NewGuid();
            _guid2 = Guid.NewGuid();
            _ticketDto = new TicketDto
            {
                Id = _guid,
                Price = 25.00,
                Date = DateTime.Now,
                Enclosure = Enclosure.NORTHERN
            };
        }

        [Benchmark]
        public void GetUsersTicketsAsync()
        {
            _ticketService.GetUsersTicketsAsync(_guid2);
        }

        [Benchmark]
        public void ReturnUsersTicketAsync()
        {
            _ticketService.ReturnUsersTicketAsync(_guid2, _guid);
        }

        [Benchmark]
        public void GetAvailableTicketsAsync()
        {
            _ticketService.GetAvailableTicketsAsync();
        }

        [Benchmark]
        public void BuyTicketAsync()
        {

            _ticketService.BuyTicketAsync(_guid2, _ticketDto);
        }

        [Benchmark]
        public void GetAllTicketsAsync()
        {
            _ticketService.GetAllTicketsAsync();
        }

    }
}
