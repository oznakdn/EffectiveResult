using Gleeman.EffectiveResult.Interfaces;

namespace Gleeman.EffectiveResult.Implementations;

public class Result : IResult
{
    public string? Message { get; private set; }
    public IEnumerable<string>? Messages { get; private set; }
    public bool IsSuccess { get; private set; }

    public static Result Success(string message = null)
    {
        return new Result
        {
            IsSuccess = true,
            Message = message
        };
    }


    public static Result Failure(string? message = null, IEnumerable<string>? messages = null)
    {
        return new Result
        {
            IsSuccess = false,
            Message = message,
            Messages = messages
        };
    }


}

public class Result<T> : IResult<T>
{
    public T? Value { get; private set; }

    public IEnumerable<T>? Values { get; private set; }

    public string? Message { get; private set; }

    public IEnumerable<string>? Messages { get; private set; }

    public bool IsSuccess { get; private set; }

    public static Result<T> Success(T value, string? message = null)
    {
        return new Result<T>
        {
            IsSuccess = true,
            Value = value,
            Message = message
        };
    }

    public static Result<T> Success(IEnumerable<T> values, string? message = null)
    {
        return new Result<T>
        {
            IsSuccess = true,
            Values = values,
            Message = message
        };
    }

    public static Result<T> Failure(string? message = null, IEnumerable<string>? messages = null)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Message = message,
            Messages = messages
        };
    }


}