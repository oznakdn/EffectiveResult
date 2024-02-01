namespace Gleeman.EffectiveResult.Interfaces;

public interface IBase
{
    string Message { get; }
    IEnumerable<string> Messages { get; }
    bool IsSuccessed { get; }
}

public interface IBase<T> : IBase
{
    T? Value { get; }
    IEnumerable<T>? Values { get; }
}