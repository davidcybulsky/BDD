using Api.DTO;
using Api.Entities;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests.Behavior.Steps;

[Binding]
public class SigningUpSteps
{
    private readonly IUserService _userService; //needs to be changed to interface TODO
    private readonly RegisterUserDto _registerUserDto = new RegisterUserDto();
    private User _resultUser;

    public SigningUpSteps()
    {
        var options = new DbContextOptionsBuilder<SafariContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _userService = new UserService(new SafariContext(options));
    }

    [Given(@"the visitor has his username, email and password in mind")]
    public void GivenTheVisitorHasHisUsernameEmailAndPasswordInMind()
    {
        _registerUserDto.Username = "user";
        _registerUserDto.Password = "pass";
        _registerUserDto.Email = "email@gmail.com";
    }

    [When(@"he enters username, syntactically valid email, password and wants to register")]
    public async void WhenHeEntersUsernameSyntacticallyValidEmailPasswordAndWantsToRegister()
    {
        _resultUser = await _userService.RegisterUser(_registerUserDto);
    }

    [Then(@"the account will be created")]
    public void ThenTheAccountWillBeCreated()
    {
        _resultUser.Should().NotBeNull();
        _resultUser.Username.Should().Be("user");
        _resultUser.Password.Should().Be("pass");
        _resultUser.Email.Should().Be("email@gmail.com");
    }
}
