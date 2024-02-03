
namespace Gleeman.EffectiveResult.Builder;

public class ResponseBuilder : AbstractBuilder
{
    public override AbstractBuilder SetMessage(string message = null, IEnumerable<string> messages = null)
    {
        Response.Message = message;
        Response.Messages = messages;
        return this;
    }

    public override AbstractBuilder SetStatusCode(int statusCode)
    {
        Response.StatusCode = statusCode;
        return this;
    }

    public override AbstractBuilder SetSuccessedOrFailed(bool isSuccessed)
    {
        Response.IsSuccess = isSuccessed;
        return this;
    }
}

public class ResponseBuilder<T> : AbstractBuilder<T>
{
    public override AbstractBuilder<T> SetMessage(string message = null, IEnumerable<string> messages = null)
    {
        Response.Message = message;
        Response.Messages = messages;
        return this;
    }

    public override AbstractBuilder<T> SetStatusCode(int statusCode)
    {
        Response.StatusCode = statusCode;
        return this;
    }

    public override AbstractBuilder<T> SetSuccessedOrFailed(bool isSuccessed)
    {
        Response.IsSuccess = isSuccessed;
        return this;
    }

    public override AbstractBuilder<T> SetValue(T value)
    {
        Response.Value = value;
        return this;
    }

    public override AbstractBuilder<T> SetValues(IEnumerable<T> values)
    {
        Response.Values = values;
        return this;
    }
}
