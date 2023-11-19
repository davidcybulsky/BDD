using Api.DTO;
using Api.Entities;

namespace Api.Interfaces;

public interface IUserService
{
    Task<User> RegisterUser(RegisterUserDto userDto);
}
