﻿
using Gleeman.EffectiveResult.Implementations;

namespace ExampleApi.Models;

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
