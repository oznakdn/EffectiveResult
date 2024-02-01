# Effective Result
### Result pattern for returning from domain and services.

`dotnet` CLI

```bash
$ dotnet add package Gleeman.EffectiveResult
```

# Result Usage

```csharp
Result<User>.Failure(messages: errors);
```

```csharp
Result.Failure(messages: errors);
```

# Response Usage

```csharp
new Response().Failure
              .AddMessage(messages: result.Messages)
              .AddStatusCode(400);

new Response<User>().Failure
                    .AddMessage(messages: result.Messages)
                    .AddStatusCode(400);
```

```csharp

new Response().Success
              .AddStatusCode(200)
              .AddMessage("User has been created successfully.");

new Response<User>() .Success
                     .AddStatusCode(200)
                     .GetValue(value: result.Value);

```


# Example

## Model
```csharp
public class User
{
    private static List<User> _users = new();
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }


    public static Result<User> CreateUser(string firstName, string lastName, string email)
    {
        var errors = new List<string>();
        if (string.IsNullOrEmpty(firstName)) errors.Add("First name cannot be empty!");
        if (string.IsNullOrEmpty(lastName)) errors.Add("Last name cannot be empty!");
        if (string.IsNullOrEmpty(email)) errors.Add("Email cannot be empty!");

        if (errors.Count > 0)
            return Result<User>.Failure(messages: errors);

        User user = new()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };

        _users.Add(user);
        return Result<User>.Success(user);
    }


    public static Result ChangeEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return Result.Failure("Email cannot be empty!");
        return Result.Success();
    }


    public static Result<User> GetUsers() => Result<User>.Success(values: _users);

```

## Service

```csharp
public class UserService : IUserService
{
    public Response<User> CreateUser(UserDto user)
    {
        var result = User.CreateUser(user.FirstName,user.LastName,user.Email);
        if(!result.IsSuccessed)
        {
            return new Response<User>()
                        .Failure
                        .AddMessage(messages: result.Messages)
                        .AddStatusCode(400);
        }

        return new Response<User>()
                         .Success
                         .AddStatusCode(200)
                         .GetValue(value: result.Value);
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
```

## Controller

```csharp

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserDto user)
    {
        var response = userService.CreateUser(user);
        return response.IsSuccessed ? Ok(new { value = response.Value, statusCode = response.StatusCode }) : BadRequest(response.Messages);
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var response = userService.GetUsers();
        return response.IsSuccessed ? Ok(new {value = response.Values , statusCode= response.StatusCode}) : NotFound(new {message = response.Message, statusCode = response.StatusCode});
    }
}
```
