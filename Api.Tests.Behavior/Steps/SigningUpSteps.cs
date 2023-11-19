using Api.DTO;
using Api.Entities;
using Api.Interfaces;
using Api.Services;

namespace Api.Tests.Behavior.Steps;

[Binding]
public class SigningUpSteps
{
    private readonly UserService _userService; //needs to be changed to interface TODO
    private readonly RegisterUserDto _registerUserDto = new RegisterUserDto();
    private User _resultUser;

    public SigningUpSteps(/*IUserService userService*/)
    {
        //_userService = userService;
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
        _resultUser.Should().Be("user");
        _resultUser.Should().Be("pass");
        _resultUser.Should().Be("email@gmail.com");
    }
}
