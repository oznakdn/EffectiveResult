# Effective Result
### Result pattern for returning from domain and services.

`dotnet` CLI

```bash
$ dotnet add package Gleeman.EffectiveResult
```

# Result Usage

```csharp
Result<User>.Failure(messages: errors);
Result<User>.Success(value:user);
```

```csharp
Result.Failure(messages: errors);
Result.Success();
```

# Response Usage

```csharp
Response<User>.Unsuccessful(statusCode:404 , error: "Not found!");

Response<User>.Successful(values: result.Values, statusCode: 200);

```

```csharp

Response.Successful(204, "User has been created successfully.");

Response.Unsuccessful(400, errors: result.Messages!);

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

}

```

## Service

```csharp
public class UserService : IUserService
{
    public IResponse CreateUser(UserDto user)
    {
        var result = User.CreateUser(user.FirstName, user.LastName, user.Email);

        if (!result.IsSuccess)
            return Response.Unsuccessful(404, errors: result.Messages!);
        
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
        return response.IsSuccess ? Ok(response) : BadRequest(response.Messages);
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        IResponse<User> response = userService.GetUsers();

        return response.IsSuccess ? Ok(response) : NotFound(response);
    }
}

```
