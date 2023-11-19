using Api.DTO;
using Api.Entities;
using Api.Interfaces;

namespace Api.Services;

public class UserService : IUserService
{

    private readonly SafariContext _context;

    public UserService(SafariContext context)
    {
        _context = context;
    }

    public async Task<User> RegisterUser(RegisterUserDto userDto)
    {
        if(!userDto.Email.Contains("@"))
        {
            return null;
        }

        var user = new User()
        {
            Id = Guid.NewGuid(),
            Username = userDto.Username,
            Email = userDto.Email,
            Password = userDto.Password,
            IsAdmin = false,
            Tickets = null
        };

        //_context.Users.Add(user);
        //_context.Users.SaveChanges();
        return user;
    }
}
