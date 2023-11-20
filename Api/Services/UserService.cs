using Api.DTO;
using Api.Entities;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }


    public async Task<User> LogIn(LoginUserDto userDto)
    {
        var user = await _context.Users.Where(u => u.Username == userDto.Username).FirstOrDefaultAsync();

        if(userDto.Password != user.Password)
        {
            return null;
        }

        return user;
    }
}
