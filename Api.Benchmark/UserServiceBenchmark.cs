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
using Microsoft.AspNetCore.Identity;

namespace Api.Benchmark
{
    public class UserServiceBenchmark
    {
        private readonly SafariContext _context;
        private readonly UserService _userService;

        private readonly LoginUserDto _loginUserDto;
        private readonly RegisterUserDto _registerUserDto;
        private readonly Guid _guid;
        private readonly Guid _guid2;

        public UserServiceBenchmark()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new SafariContext(options);
            _userService = new UserService(_context);

            _guid = Guid.NewGuid();
            _guid2 = Guid.NewGuid();
            _loginUserDto = new LoginUserDto
            {
                Username = "Bodzio",
                Password = "Meble"
            };
            _registerUserDto = new RegisterUserDto
            {
                Username = "Bodzio",
                Password = "Meble",
                Email = "bodzio@meble.com"
            };
        }

        [Benchmark]
        public void RegisterUser()
        {
            _userService.RegisterUser(_registerUserDto);
        }

        [Benchmark]
        public void LogIn()
        {
            _userService.LogIn(_loginUserDto);
        }

        [Benchmark]
        public void DeleteUser()
        {
            _userService.DeleteUser(_loginUserDto);
        }

        [Benchmark]
        public void GetAll()
        {
            _userService.GetAll();
        }
    }
}
