using ExampleApi.Dtos;
using ExampleApi.Models;
using Gleeman.EffectiveResult.Implementations;

namespace ExampleApi.Services;

public interface IUserService
{
    Response<User> GetUsers();
    Response CreateUser(UserDto user);

}
