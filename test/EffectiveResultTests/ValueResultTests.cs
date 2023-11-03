namespace EffectiveResultTests;

public class ValueResultTests
{
    [Fact]
    public void CreateUser_When_ParameterInvalid_Should_Return_Failed()
    {
        var result = User.CreateUser("TestName","TestSurname","");
        Assert.True(result.IsFailed);
        Assert.Equal<string>(result.Errors.First(), "Email cannot be empty!");
        Assert.Null(result.Value);
    }

    [Fact]
    public void CreateUser_When_ParameterIsValid_Should_Return_Successed()
    {
        var result = User.CreateUser("TestName", "TestSurname", "test@mail.com");
        Assert.True(result.IsSuccessed);
        Assert.NotNull(result.Value);
    }

    [Fact]
    public void GetUsers_Should_Return_Successed()
    {
        var result = User.GetUsers();
        Assert.True(result.IsSuccessed);
        Assert.NotNull(result.Values);
    }
}
