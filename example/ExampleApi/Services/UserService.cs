using ExampleApi.Dtos;
using ExampleApi.Models;
using Gleeman.EffectiveResult.Implementations;
using Gleeman.EffectiveResult.Interfaces;

namespace ExampleApi.Services;

public class UserService : IUserService
{
    public IResponse CreateUser(UserDto user)
    {
        var result = User.CreateUser(user.FirstName, user.LastName, user.Email);
        if (!result.IsSuccess)
        {
            return Response.Unsuccessful(404, errors: result.Messages!);

        }

        return Response.Successful(200, "User has been created successfully.");

    }

    public IResponse<User> GetUsers()
    {
        var result = User.GetUsers();

        if (result.Values!.Count() == 0)
            return Response<User>.Unsuccessful(statusCode: 404, error: "There is no any user!");



        return Response<User>.Successful(values: result.Values!, statusCode: 200);


    }
}
