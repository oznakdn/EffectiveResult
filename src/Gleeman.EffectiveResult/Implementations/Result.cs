using Gleeman.EffectiveResult.Interfaces;

namespace Gleeman.EffectiveResult.Implementations;

public class Result : IResult
{
    public string? Message { get; private set; }
    public IEnumerable<string>? Messages { get; private set; }
    public bool IsSuccessed { get; private set; }

    public static Result Success(string message = null)
    {
        return new Result
        {
            IsSuccessed = true,
            Message = message ?? string.Empty,
            Messages = Enumerable.Empty<string>()
        };
    }


    public static Result Failure(string? message = null, IEnumerable<string>? messages = null)
    {
        return new Result
        {
            IsSuccessed = false,
            Message = message ?? string.Empty,
            Messages = messages ?? Enumerable.Empty<string>()
        };
    }


}

public class Result<T> : IResult<T>
{
    public T? Value { get; private set; }

    public IEnumerable<T>? Values { get; private set; }

    public string? Message { get; private set; }

    public IEnumerable<string>? Messages { get; private set; }

    public bool IsSuccessed { get; private set; }


    public static Result<T> Success(T value, string? message = null)
    {
        return new Result<T>
        {
            IsSuccessed = true,
            Value = value,
            Message = message ?? string.Empty,
        };
    }

    public static Result<T> Success(IEnumerable<T> values, string? message = null)
    {
        return new Result<T>
        {
            IsSuccessed = true,
            Values = values,
            Message = message ?? string.Empty,
        };
    }

    public static Result<T> Failure(string? message = null, IEnumerable<string>? messages = null)
    {
        return new Result<T>
        {
            IsSuccessed = false,
            Message = message ?? string.Empty,
            Messages = messages ?? Enumerable.Empty<string>(),
            Values = Enumerable.Empty<T>(),
        };
    }


}