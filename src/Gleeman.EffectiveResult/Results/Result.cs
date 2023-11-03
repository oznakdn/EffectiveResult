using Gleeman.EffectiveResult.Interfaces;

namespace Gleeman.EffectiveResult.Results;

public sealed class Result : IResult
{
    public string Message { get; private set; }

    public IEnumerable<string> Errors { get; private set; }

    public bool IsFailed { get; private set; }

    public bool IsSuccessed { get; private set; }


    public static Result Ok(string message = null)
    {
        return new Result
        {
            IsSuccessed = true,
            IsFailed = false,
            Message = message ?? string.Empty,
            Errors = Enumerable.Empty<string>()
        };
    }

    public static Result Fail(string errorMessage = null, IEnumerable<string> errorMessages = null)
    {
        return new Result
        {
            IsFailed = true,
            IsSuccessed = false,
            Message = errorMessage ?? string.Empty,
            Errors = errorMessages ?? Enumerable.Empty<string>()
        };
    }

}
