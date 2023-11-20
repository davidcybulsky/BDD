using Api.DTO;
using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps;

[Binding]
public class LoggingInSteps
{
    private readonly SafariContext _context;
    private readonly IUserService _userService; //needs to be changed to interface TODO
    private readonly LoginUserDto _loginUserDto = new LoginUserDto();
    private User _resultUser;

    public LoggingInSteps()
    {
        var options = new DbContextOptionsBuilder<SafariContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _context = new SafariContext(options);
        _userService = new UserService(_context);
    }

    [Given(@"the visitor remembers his username and password")]
    public void GivenTheVisitorRemembersHisUsernameAndPassword()
    {
        _loginUserDto.Username = "user";
        _loginUserDto.Password = "pass";
    }

    [Given(@"user exists in the database")]
    public void GivenUserExistsInTheDatabase()
    {
        _context.Add(new User
        {
            Username = "user",
            Password = "pass",
            Email = "email@gmail.com"
        });
        _context.SaveChanges();
    }


    [When(@"he enters his username and password and wants to log in")]
    public async void WhenHeEntersHisUsernameAndPasswordAndWantsToLogIn()
    {
        _resultUser = await _userService.LogIn(_loginUserDto);
    }


    [Then(@"he will be logged in")]
    public void ThenHeWillBeLoggedIn()
    {
        _resultUser.Should().NotBeNull();
        _resultUser.Username.Should().Be("user");
        _resultUser.Password.Should().Be("pass");
    }
}
