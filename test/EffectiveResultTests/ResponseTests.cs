using Gleeman.EffectiveResult.Interfaces;

namespace EffectiveResultTests;

public class ResponseTests
{
    [Fact]
    public void Create_When_ParamersAreNull_ShouldBe_Return_FailureResponse()
    {
        IResponse<User> response = User.Create("", "", "");
        Assert.False(response.IsSuccess);
        Assert.Equal(3, response.Messages.Count());
        Assert.Equal("First name cannot be empty!", response.Messages.ToList()[0]);
        Assert.Equal(400, response.StatusCode);
    }

    [Fact]
    public void Create_When_ParamersAreNotNull_ShouldBe_Return_SuccessResponse()
    {
        var response = User.Create("TestName", "TestLastname", "testmail@mail.com");
        Assert.True(response.IsSuccess);
        Assert.Null(response.Messages);
        Assert.Equal("User has been created successfully", response.Message);
        Assert.Equal(200, response.StatusCode);
        Assert.NotNull(response.Value);
    }

    [Fact]
    public void Get_ShouldBe_Return_FailureResponse()
    {
        var response = User.Get();

        Assert.False(response.IsSuccess);
        Assert.Null(response.Messages);
        Assert.Equal("There is no any user!", response.Message);
        Assert.Equal(404, response.StatusCode);
        Assert.Null(response.Values);
        Assert.Null(response.Value);

    }

    [Fact]
    public void Get_ShouldBe_Return_SuccessResponse()
    {

        User.Create("TestName", "TestLastname", "testmail@mail.com");
        var response = User.Get();

        Assert.True(response.IsSuccess);
        Assert.Null(response.Message);
        Assert.Equal(200, response.StatusCode);
        Assert.Null(response.Value);
        Assert.NotNull(response.Values);

    }


}
