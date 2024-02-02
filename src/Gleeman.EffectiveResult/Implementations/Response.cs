using Gleeman.EffectiveResult.Interfaces;

namespace Gleeman.EffectiveResult.Implementations;

public class Response : IResponse
{
    public bool IsSuccess { get; private set; }

    public int? StatusCode { get; private set; }

    public string Message { get; private set; }

    public IEnumerable<string> Messages { get; private set; }


    public static Response Successful(int? statusCode = null, string message = null)
    {
        return new Response
        {
            IsSuccess = true,
            StatusCode = statusCode,
            Message = message
        };
    }

    public static Response Unsuccessful(int? statusCode = null, string error = null, IEnumerable<string> errors = null)
    {
        return new Response
        {
            IsSuccess = false,
            StatusCode = statusCode,
            Message = error,
            Messages = errors
        };
    }


}

public class Response<T> : IResponse<T>
{

    public bool IsSuccess { get; private set; }
    public int? StatusCode { get; private set; }
    public string? Message { get; private set; }
    public IEnumerable<string>? Messages { get; private set; }
    public T? Value { get; private set; }
    public IEnumerable<T>? Values { get; private set; }


    public static Response<T> Successful(int? statusCode = null, string message = null)
    {
        return new Response<T>
        {
            IsSuccess = true,
            StatusCode = statusCode,
            Message = message
        };
    }

    public static Response<T> Successful(T value, int? statusCode = null, string message = null)
    {
        return new Response<T>
        {
            IsSuccess = true,
            Value = value,
            StatusCode = statusCode,
            Message = message
        };
    }

    public static Response<T> Successful(IEnumerable<T> values, int? statusCode = null, string message = null)
    {
        return new Response<T>
        {
            IsSuccess = true,
            Values = values,
            StatusCode = statusCode,
            Message = message
        };
    }

    public static Response<T> Unsuccessful(int? statusCode = null, string error = null, IEnumerable<string> errors = null)
    {
        return new Response<T>
        {
            IsSuccess = false,
            StatusCode = statusCode,
            Message = error,
            Messages = errors
        };
    }


}