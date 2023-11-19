using Api.DTO;
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


    [HttpPost("register")]
    public async Task<ActionResult<User>> RegisterUser([FromBody] RegisterUserDto userDto)
    {
        var user = await _userService.RegisterUser(userDto);
        if(user == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(RegisterUser), new { id = user.Id }, user);
    }
}
