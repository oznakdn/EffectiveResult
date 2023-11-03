namespace Gleeman.EffectiveResult.Interfaces;

public interface IValueResult<out T>:IResult
{
    T Value { get; }
    IEnumerable<T> Values { get; }
}
