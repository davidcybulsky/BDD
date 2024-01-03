using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Client.Selenium.Tests;

public class SeleniumTests : IDisposable
{
    private IWebDriver _driver;
    private readonly string _baseUrl = "http://localhost:3000";
    public SeleniumTests()
    {
        _driver = new FirefoxDriver();
    }

    [Fact]
    public void LoggingInWithFilledFields_SchouldBeSuccessfull()
    {
        //Arrange
        var userName = "Arkadiusz";
        var password = "Arkadiusz123";
        var homePageUrl = $"{_baseUrl}/app";

        //Act
        _driver.Navigate().GoToUrl($"{_baseUrl}");
        var nameInput = _driver.FindElement(By.Id("login-login-input"));
        nameInput.SendKeys(userName);
        var passwordInput = _driver.FindElement(By.Id("password-login-input"));
        passwordInput.SendKeys(password);
        var loginButton = _driver.FindElement(By.Id("login-btn"));
        loginButton.Click();
        Thread.Sleep(10000);

        //Assert
        _driver.Url.Should().Be(homePageUrl);
    }

    [Fact]
    public void LoggingInWithoutFilledFields_SchouldShowAlert()
    {
        //Arrange
        var message = "Values cannot be empty!";

        //Act
        _driver.Navigate().GoToUrl($"{_baseUrl}");
        var loginButton = _driver.FindElement(By.Id("login-btn"));
        loginButton.Click();
        var alert = _driver.FindElement(By.Id("errMsg-Login"));

        //Assert
        alert.Text.Should().Be(message);
    }

    [Fact]
    public void ClickingRegister_SchouldNavigateToRegisterUrl()
    {
        //Arrange
        var registerUrl = $"{_baseUrl}/register";

        //Act
        _driver.Navigate().GoToUrl($"{_baseUrl}");
        var registerButton = _driver.FindElement(By.Id("register-nav-btn"));
        registerButton.Click();

        //Assert
        _driver.Url.Should().Be(registerUrl);
    }

    [Fact]
    public void RegisteringWithFilledFields_SchouldBeSuccessfull()
    {
        //Arrange
        var userName = "Arkadiusz";
        var email = "arkadiusz@gmail.com";
        var password = "Arkadiusz123";
        var registerUrl = $"{_baseUrl}/register";
        var homePageUrl = $"{_baseUrl}/app";

        //Act
        _driver.Navigate().GoToUrl(registerUrl);
        var emailInput = _driver.FindElement(By.Id("email-register-input"));
        emailInput.SendKeys(email);
        var nameInput = _driver.FindElement(By.Id("login-register-input"));
        nameInput.SendKeys(userName);
        var passwordInput = _driver.FindElement(By.Id("password-register-input"));
        passwordInput.SendKeys(password);
        var registerButton = _driver.FindElement(By.Id("register-btn"));
        registerButton.Click();
        Thread.Sleep(1000);

        //Assert
        _driver.Url.Should().Be(homePageUrl);
    }

    [Fact]
    public void RegisteringWithEmptyFields_SchouldShowAlertMessage()
    {
        //Arrange
        var registerUrl = $"{_baseUrl}/register";
        var message = "Values cannot be empty!";

        //Act
        _driver.Navigate().GoToUrl(registerUrl);
        var registerButton = _driver.FindElement(By.Id("register-btn"));
        registerButton.Click();

        //Assert
        var alert = _driver.FindElement(By.Id("errMsg-Register"));
        alert.Text.Should().Be(message);
    }

    [Fact]
    public void RegisteringWithPasswordLengthFive_SchouldShowAlertMessage()
    {
        //Arrange
        var userName = "Arkadiusz";
        var email = "arkadiusz@gmail.com";
        var password = "12345";
        var registerUrl = $"{_baseUrl}/register";
        var message = "Password must contain at least 6 characters";

        //Act
        _driver.Navigate().GoToUrl(registerUrl);
        var emailInput = _driver.FindElement(By.Id("email-register-input"));
        emailInput.SendKeys(email);
        var nameInput = _driver.FindElement(By.Id("login-register-input"));
        nameInput.SendKeys(userName);
        var passwordInput = _driver.FindElement(By.Id("password-register-input"));
        passwordInput.SendKeys(password);
        var registerButton = _driver.FindElement(By.Id("register-btn"));
        registerButton.Click();

        //Assert
        var alert = _driver.FindElement(By.Id("errMsg-Register"));
        alert.Text.Should().Be(message);
    }

    [Fact]
    public void RegisteringWithEmailSymbol_SchouldShowAlertMessage()
    {
        //Arrange
        var userName = "Arkadiusz";
        var email = "arkadiuszgmail.com";
        var password = "123456";
        var registerUrl = $"{_baseUrl}/register";
        var message = "Email must contain '@' !";

        //Act
        _driver.Navigate().GoToUrl(registerUrl);
        var emailInput = _driver.FindElement(By.Id("email-register-input"));
        emailInput.SendKeys(email);
        var nameInput = _driver.FindElement(By.Id("login-register-input"));
        nameInput.SendKeys(userName);
        var passwordInput = _driver.FindElement(By.Id("password-register-input"));
        passwordInput.SendKeys(password);
        var registerButton = _driver.FindElement(By.Id("register-btn"));
        registerButton.Click();

        //Assert
        var alert = _driver.FindElement(By.Id("errMsg-Register"));
        alert.Text.Should().Be(message);
    }

    [Fact]
    public void Logout_SchouldNavigateToBaseUrl()
    {
        //Arrange
        var userName = "Arkadiusz";
        var password = "Arkadiusz123";

        //Act
        _driver.Navigate().GoToUrl($"{_baseUrl}");
        var nameInput = _driver.FindElement(By.Id("login-login-input"));
        nameInput.SendKeys(userName);
        var passwordInput = _driver.FindElement(By.Id("password-login-input"));
        passwordInput.SendKeys(password);
        var loginButton = _driver.FindElement(By.Id("login-btn"));
        loginButton.Click();
        Thread.Sleep(10000);

        var logoutButton = _driver.FindElement(By.Id("logout-btn"));
        logoutButton.Click();

        //Assert
        _driver.Url.Should().Be(_baseUrl);
    }

    [Fact]
    public void NavCaretakerButton_SchouldShowAnimalTable()
    {
        //Arrange
        var userName = "Arkadiusz";
        var password = "Arkadiusz123";

        //Act
        _driver.Navigate().GoToUrl($"{_baseUrl}");
        var nameInput = _driver.FindElement(By.Id("login-login-input"));
        nameInput.SendKeys(userName);
        var passwordInput = _driver.FindElement(By.Id("password-login-input"));
        passwordInput.SendKeys(password);
        var loginButton = _driver.FindElement(By.Id("login-btn"));
        loginButton.Click();
        Thread.Sleep(10000);

        var navCaretakerButton = _driver.FindElement(By.Id("nav-caretaker"));
        navCaretakerButton.Click();

        //Assert
        var caretakerTable = _driver.FindElement(By.Id("caretaker-tbl"));
        caretakerTable.Should().NotBeNull();
    }


    [Fact]
    public void NavAnimalButton_SchouldShowAnimalTable()
    {
        //Arrange
        var userName = "Arkadiusz";
        var password = "Arkadiusz123";

        //Act
        _driver.Navigate().GoToUrl($"{_baseUrl}");
        var nameInput = _driver.FindElement(By.Id("login-login-input"));
        nameInput.SendKeys(userName);
        var passwordInput = _driver.FindElement(By.Id("password-login-input"));
        passwordInput.SendKeys(password);
        var loginButton = _driver.FindElement(By.Id("login-btn"));
        loginButton.Click();
        Thread.Sleep(10000);

        var navCaretakerButton = _driver.FindElement(By.Id("nav-caretaker"));
        navCaretakerButton.Click();

        var navAnimalButton = _driver.FindElement(By.Id("nav-animal"));
        navAnimalButton.Click();

        //Assert
        var animalTable = _driver.FindElement(By.Id("animal-tbl"));
        animalTable.Should().NotBeNull();
    }

    public void Dispose()
    {
        _driver.Quit();
    }
}