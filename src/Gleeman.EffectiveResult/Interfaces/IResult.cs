namespace Gleeman.EffectiveResult.Interfaces;

public interface IResult
{
    string Message { get; }
    IEnumerable<string> Messages { get; }
    bool IsSuccess { get; }
}

public interface IResult<T>
{
    string Message { get; }
    IEnumerable<string> Messages { get; }
    bool IsSuccess { get; }
}
