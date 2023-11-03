# Effective Result
`dotnet` CLI

```bash
$ dotnet add package Gleeman.EffectiveResult --version 7.0.0
```


```csharp
Result<T> Ok(T value = null, IEnumerable<T> values = null, string message = null)
Result<T> Fail(string errorMessage = null, IEnumerable<string> errorMessages = null)
```

```csharp
Result Ok(string message = null)
Result Fail(string errorMessage = null, IEnumerable<string> errorMessages = null)
```

## USAGE


```csharp
public class User
{
    private static List<User> _users = new();
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    public User()
    {
        _users.AddRange(new List<User>
        {
            new User
            {
                FirstName = "Abc",
                LastName = "ABC",
                Email = "abc@mail.com"
            },
            new User
            {
                FirstName = "Cde",
                LastName = "CDE",
                Email = "cde@mail.com"
            },
            new User
            {
                FirstName = "Fgh",
                LastName = "FGH",
                Email = "fgh@mail.com"
            }
        });
    }

    public static Result<User> CreateUser(string firstName, string lastName, string email)
    {
        var errors = new List<string>();
        if (string.IsNullOrEmpty(firstName)) errors.Add("First name cannont be empty!");
        if (string.IsNullOrEmpty(lastName)) errors.Add("Last name cannont be empty!");
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

    public static Result ChangeEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return Result.Fail("Email cannot be empty!");
        return Result.Ok();
    }

    public static Result<User> GetUsers() => Result<User>.Ok(values: _users);
}
```
