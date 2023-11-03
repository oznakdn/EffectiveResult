namespace Gleeman.EffectiveResult.Interfaces;

public interface IResult
{
    string Message { get; }
    IEnumerable<string> Errors { get; }
    bool IsFailed { get; }
    bool IsSuccessed { get; }
}
