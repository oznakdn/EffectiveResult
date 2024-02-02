namespace Gleeman.EffectiveResult.Interfaces;

public interface IResponse
{
    int? StatusCode { get; }
    string? Message { get; }
    IEnumerable<string>?Messages { get; }
    bool IsSuccess { get; }
    
}

public interface IResponse<T> : IResponse
{
    public T? Value { get; }
    public IEnumerable<T>? Values { get;}
}