using Gleeman.EffectiveResult.Interfaces;

namespace Gleeman.EffectiveResult.Implementations;

public class Response : IResponse
{

    public int? StatusCode { get; private set; }

    public string? Message { get; private set; }

    public IEnumerable<string>? Messages { get; private set; }

    public bool IsSuccessed { get; private set; }


    public Response AddMessage(string? message = null, IEnumerable<string>? messages = null)
    {
        Message = message ?? string.Empty;
        Messages = messages ?? Enumerable.Empty<string>();
        return this;
    }


    public Response AddStatusCode(int statusCode)
    {
        StatusCode = statusCode;
        return this;
    }

    public Response Success
    {
        get
        {
            IsSuccessed = true;
            return this;
        }
    }

    public Response Failure
    {
        get
        {
            IsSuccessed = false;
            return this;
        }
    }


}

public class Response<T> : IResponse<T>
{
    public int? StatusCode { get; private set; }
    public bool IsSuccessed { get; private set; }
    public string? Message { get; private set; }
    public IEnumerable<string>? Messages { get; private set; }
    public T? Value { get; private set; }
    public IEnumerable<T>? Values { get; private set; }



    public Response<T> Success
    {
        get
        {
            IsSuccessed = true;
            return this;
        }
    }

    public Response<T> Failure
    {
        get
        {
            IsSuccessed = false;
            return this;
        }
    }


    public Response<T> AddMessage(string? message = null, IEnumerable<string>? messages = null)
    {
        Message = message ?? string.Empty;
        Messages = messages ?? Enumerable.Empty<string>();
        return this;
    }

    public Response<T> AddStatusCode(int statusCode)
    {
        StatusCode = statusCode;
        return this;
    }

    public Response<T> GetValue(T value)
    {
        Value = value;
        return this;
    }

    public Response<T> GetValue(IEnumerable<T> values)
    {
        Values = values;
        return this;
    }
}