using Gleeman.EffectiveResult.Implementations;

namespace Gleeman.EffectiveResult.Interfaces;

public interface IResponse : IBase
{
    int? StatusCode { get; }
    Response AddMessage(string? message = null, IEnumerable<string>? messages = null);
    Response AddStatusCode(int statusCode);
    Response Success { get; }
    Response Failure { get; }
}

public interface IResponse<T> : IBase<T>
{
    int? StatusCode { get; }
    Response<T> AddMessage(string? message = null, IEnumerable<string>? messages = null);
    Response<T> AddStatusCode(int statusCode);
    Response<T> Success { get; }
    Response<T> Failure { get;}
    Response<T> GetValue(T value);
    Response<T> GetValue(IEnumerable<T> values);
}