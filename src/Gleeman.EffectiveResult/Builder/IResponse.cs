namespace Gleeman.EffectiveResult.Builder;

public interface IResponse
{
    int? StatusCode { get; set; }
    string? Message { get; set; }
    IEnumerable<string>? Messages { get; set; }
    bool IsSuccess { get; set; }
}


public interface IResponse<T> : IResponse
{
    public T? Value { get; set; }
    public IEnumerable<T>? Values { get; set; }
}
