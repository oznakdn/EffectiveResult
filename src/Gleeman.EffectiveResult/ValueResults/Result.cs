using Gleeman.EffectiveResult.Interfaces;

namespace Gleeman.EffectiveResult.ValueResults;

public sealed class Result<T> : IValueResult<T>
where T : class
{
    public T Value { get; private set; }
    public IEnumerable<T> Values { get; private set; }
    public string Message { get; private set; }
    public IEnumerable<string> Errors { get; private set; }
    public bool IsFailed { get; private set; }
    public bool IsSuccessed { get; private set; }

    public static Result<T> Ok(T value = null, IEnumerable<T> values = null, string message = null)
    {
        return new Result<T>
        {
            IsSuccessed = true,
            IsFailed = false,
            Value = value,
            Values = values ?? Enumerable.Empty<T>(),
            Message = message ?? string.Empty,
            Errors = Enumerable.Empty<string>()
        };
    }

    public static Result<T> Fail(string errorMessage = null, IEnumerable<string> errorMessages = null)
    {
        return new Result<T>
        {
            IsFailed = true,
            IsSuccessed = false,
            Errors = errorMessages ?? Enumerable.Empty<string>(),
            Message = errorMessage ?? string.Empty,
            Value = null,
            Values = Enumerable.Empty<T>(),
        };
    }

}
