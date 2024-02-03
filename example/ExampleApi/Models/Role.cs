using Gleeman.EffectiveResult.Builder;

namespace ExampleApi.Models;

public class Role
{
    public string Title { get; private set; }

    private static List<Role> _roles = new();

    public Role(string title)
    {
        Title = title;
    }

    public static IResponse CreateRole(Role role)
    {
        AbstractBuilder builder = new ResponseBuilder();

        if (string.IsNullOrEmpty(role.Title))
        {
            builder = builder.SetMessage("Title cannot be null!")
                             .SetStatusCode(400)
                             .SetSuccessedOrFailed(false);
        }
        else
        {
            _roles.Add(role);
            builder = builder.SetMessage("Role has been added.")
                             .SetStatusCode(400)
                             .SetSuccessedOrFailed(true);
        }

        Response result = builder.Build;
        return result;

    }

    public static IResponse<Role>GetRoles()
    {
        AbstractBuilder<Role> builder = new ResponseBuilder<Role>();

        if(_roles.Count == 0)
        {
            builder = builder.
                              SetMessage("There is no any role!")
                             .SetStatusCode(404)
                             .SetSuccessedOrFailed(false)
                             .SetValues(_roles);
        }
        else
        {
            builder = builder
                             .SetStatusCode(200)
                             .SetSuccessedOrFailed(true)
                             .SetValues(_roles);
        }

        var result = builder.Build;
        return result;

    }
}
