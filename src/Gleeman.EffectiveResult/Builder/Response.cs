
namespace Gleeman.EffectiveResult.Builder;

public class Response : IResponse
{
    public int? StatusCode { get; set; }

    public string? Message { get; set; }

    public IEnumerable<string>? Messages { get; set; }

    public bool IsSuccess { get; set; }
}

public class Response<T> : IResponse<T>
{

    public bool IsSuccess { get;  set; }
    public int? StatusCode { get;  set; }
    public string? Message { get;  set; }
    public IEnumerable<string>? Messages { get;  set; }
    public T? Value { get;  set; }
    public IEnumerable<T>? Values { get; set; }



}
