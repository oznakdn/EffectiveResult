namespace Gleeman.EffectiveResult.Builder;

public abstract class AbstractBuilder
{
    protected Response Response { get; set; }
    public AbstractBuilder()
    {
        Response = new Response();
    }

    public abstract AbstractBuilder SetMessage(string message = null, IEnumerable<string>messages = null);
    public abstract AbstractBuilder SetStatusCode(int statusCode);
    public abstract AbstractBuilder SetSuccessedOrFailed(bool isSuccessed);

    public Response Build => Response;

}

public abstract class AbstractBuilder<T>
{
    protected Response<T> Response { get; set; }
    public AbstractBuilder()
    {
        Response = new Response<T>();
    }

    public abstract AbstractBuilder<T> SetMessage(string message = null, IEnumerable<string> messages = null);
    public abstract AbstractBuilder<T> SetStatusCode(int statusCode);
    public abstract AbstractBuilder<T> SetSuccessedOrFailed(bool isSuccessed);
    public abstract AbstractBuilder<T> SetValue(T value);
    public abstract AbstractBuilder<T> SetValues(IEnumerable<T> values);


    public Response<T> Build => Response;

}