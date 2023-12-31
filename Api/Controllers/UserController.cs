﻿using Api.DTO;
using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet()]
    public async Task<ActionResult<User>> GetAllUsers()
    {
        var users = await _userService.GetAll();
        return Ok(users);
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> LogIn([FromBody] LoginUserDto userDto)
    {
        var user = await _userService.LogIn(userDto);
        if (user == null)
        {
            return BadRequest();
        }
        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> RegisterUser([FromBody] RegisterUserDto userDto)
    {
        var user = await _userService.RegisterUser(userDto);
        if (user == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(RegisterUser), new { id = user.Id }, user);
    }

    

    [HttpDelete("delete")]
    public async Task<ActionResult<User>> DeleteUser([FromBody] LoginUserDto userDto)
    {
        var user = await _userService.DeleteUser(userDto);
        if (user == null)
        {
            return BadRequest();
        }
        return Ok(user);
    }
}
