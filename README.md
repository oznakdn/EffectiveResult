# Effective Result
### Result pattern for returning from domain and services.

`dotnet` CLI

```bash
$ dotnet add package Gleeman.EffectiveResult
```


```csharp
Result<T> Ok(T value = null, IEnumerable<T> values = null, string message = null)
Result<T> OkAsync(T value = null, IEnumerable<T> values = null, string message = null)
Result<T> Fail(string errorMessage = null, IEnumerable<string> errorMessages = null)
Result<T> FailAsync(string errorMessage = null, IEnumerable<string> errorMessages = null)

```

```csharp
Result Ok(string message = null)
Result OkAsync(string message = null)
Result Fail(string errorMessage = null, IEnumerable<string> errorMessages = null)
Result FailAsync(string errorMessage = null, IEnumerable<string> errorMessages = null)
```

## USAGE


```csharp
public class User
{
    private static List<User> _users = new();
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    // CreateUser Sync
    public static Result<User> CreateUser(string firstName, string lastName, string email)
    {
        var errors = new List<string>();
        if (string.IsNullOrEmpty(firstName)) errors.Add("First name cannot be empty!");
        if (string.IsNullOrEmpty(lastName)) errors.Add("Last name cannot be empty!");
        if (string.IsNullOrEmpty(email)) errors.Add("Email cannot be empty!");

        if (errors.Count > 0)
            return Result<User>.Fail(errorMessages: errors);

        User user = new()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };

        _users.Add(user);
        return Result<User>.Ok(user);
    }

    // CreateUser Async
    public static async Task<Result<User>> CreateUserAsync(string firstName, string lastName, string email)
    {
        var errors = new List<string>();
        if (string.IsNullOrEmpty(firstName)) errors.Add("First name cannot be empty!");
        if (string.IsNullOrEmpty(lastName)) errors.Add("Last name cannot be empty!");
        if (string.IsNullOrEmpty(email)) errors.Add("Email cannot be empty!");

        if (errors.Count > 0)
            return await Result<User>.FailAsync(errorMessages: errors);

        User user = new()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };
       _users.Add(user);
        return await Result<User>.OkAsync(user);
    }

    // ChangeEmail Sync
    public static Result ChangeEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return Result.Fail("Email cannot be empty!");
        return Result.Ok();
    }

    // ChangeEmail Async
    public static async Task<Result> ChangeEmailAsync(string email)
    {
        if (string.IsNullOrEmpty(email))
            return await Result.FailAsync("Email cannot be empty!");
        return await Result.OkAsync();
    }

    // GetUsers
    public static Result<User> GetUsers()
      => Result<User>.Ok(values: _users);
}
```
