using Api.DTO;
using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps
{
    [Binding]
    public class DeletingAccountSteps
    {
        private readonly SafariContext _context;
        private readonly IUserService _service;
        private static readonly Guid _guid = Guid.NewGuid();
        private static readonly string _username = "admin@gmail.com";
        private static readonly string _password = "password";
        private User _loggedUser = null;
        private User _userDeleted = null;

        private readonly User _user = new()
        {
            Id = _guid,
            Email = _username,
            IsAdmin = true,
            Password = _password,
            Username = _username
        };
        private readonly LoginUserDto loginUserDto = new()
        {
            Username = _username,
            Password = _password,
        };

        public DeletingAccountSteps()
        {
            var options = new DbContextOptionsBuilder<SafariContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            _context = new SafariContext(options);
            _service = new UserService(_context);

        }

        [Given(@"the visitor is logged into his account")]
        public async void Given()
        {
            await _context.AddAsync(_user);
            await _context.SaveChangesAsync();
        }

        [Given(@"he sees his main profile page")]
        public async void Given2()
        {
            _loggedUser = await _service.LogIn(loginUserDto);
        }

        [When(@"he gives instruction to delete his account")]
        public void When()
        {
            _service.DeleteUser(loginUserDto);
        }

        [When(@"he agrees that he is sure he wants to delete it")]
        public async void When2()
        {
            _userDeleted = await _context.Users.FirstOrDefaultAsync(x => x.Username == _username);
        }

        [Then(@"the account is deleted")]
        public void Then()
        {
            Assert.Null(_userDeleted);
        }

        [Then(@"the user is automatically logged out")]
        public void Then2()
        {
            Assert.NotNull(_loggedUser);
        }
    }
}
