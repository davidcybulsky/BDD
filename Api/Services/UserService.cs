﻿using Api.DTO;
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

    public async Task<IEnumerable<User>> GetAll()
    {
        var users = await _context.Users.Include(u => u.Tickets).ToListAsync();
        return users;
    }

    public async Task<User> LogIn(LoginUserDto userDto)
    {
        var user = await _context.Users.Where(u => u.Username == userDto.Username).FirstOrDefaultAsync();

        if (userDto.Password != user.Password)
        {
            return null;
        }

        return user;
    }

    public async Task<User> RegisterUser(RegisterUserDto userDto)
    {
        if (!userDto.Email.Contains("@"))
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

    public async Task<User> DeleteUser(LoginUserDto userDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userDto.Username);

        if (user is not null && user.Password == userDto.Password)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
        return null;
    }
}
