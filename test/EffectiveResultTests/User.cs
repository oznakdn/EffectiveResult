using Gleeman.EffectiveResult.Results;
using Gleeman.EffectiveResult.ValueResults;

namespace EffectiveResultTests;

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

    public static Result ChangeEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return Result.Fail("Email cannot be empty!");
        return Result.Ok();
    }

    public static async Task<Result> ChangeEmailAsync(string email)
    {
        if (string.IsNullOrEmpty(email))
            return await Result.FailAsync("Email cannot be empty!");
        return await Result.OkAsync();
    }

    public static Result<User> GetUsers() => Result<User>.Ok(values: _users);
}
