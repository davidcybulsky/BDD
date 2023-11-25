using Api.DTO;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Interfaces;

public interface IUserService
{
    Task<User> RegisterUser(RegisterUserDto userDto);
    Task<User> LogIn(LoginUserDto userDto);
    Task<User> DeleteUser(LoginUserDto userDto);
    Task<IEnumerable<User>> GetAll();
}
