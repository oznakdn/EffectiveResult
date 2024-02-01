using ExampleApi.Dtos;
using ExampleApi.Models;
using Gleeman.EffectiveResult.Implementations;

namespace ExampleApi.Services;

public class UserService : IUserService
{
    public Response CreateUser(UserDto user)
    {
        var result = User.CreateUser(user.FirstName,user.LastName,user.Email);
        if(!result.IsSuccessed)
        {
            return new Response()
                        .Failure
                        .AddMessage(messages: result.Messages)
                        .AddStatusCode(400);
        }

        return new Response()
                         .Success
                         .AddStatusCode(200)
                         .AddMessage("User has been created successfully.");
    }

    public Response<User> GetUsers()
    {
        var result = User.GetUsers();

        if (result.Values.Count() == 0)
            return new Response<User>()
                        .Failure
                        .AddMessage("There is no any user!")
                        .AddStatusCode(200);

        return new Response<User>()
                        .Success
                        .AddStatusCode(200)
                        .GetValue(result.Values);

    }
}
