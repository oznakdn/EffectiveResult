using ExampleApi.Dtos;
using ExampleApi.Models;
using Gleeman.EffectiveResult.Interfaces;

namespace ExampleApi.Services;

public interface IUserService
{
    IResponse<User> GetUsers();
    IResponse CreateUser(UserDto user);

}
