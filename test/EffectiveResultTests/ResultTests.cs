namespace EffectiveResultTests;

public class ResultTests
{
    [Fact]
    public void ChangeEmail_When_ParameterInvalid_Should_Return_Failed()
    {
        var result = User.ChangeEmail("");
        Assert.False(result.IsSuccessed);
        Assert.Equal<string>(result.Message, "Email cannot be empty!");
        Assert.NotEmpty(result.Message);
        Assert.Empty(result.Messages);
    }

    [Fact]
    public void ChangeEmail_When_ParameterIsValid_Should_Return_Successed()
    {
        var result = User.ChangeEmail("test@mail.com");
        Assert.True(result.IsSuccessed);
        Assert.Empty(result.Message);
        Assert.Empty(result.Messages);

    }



    [Fact]
    public void CreateUser_When_ParameterInvalid_Should_Return_Failed()
    {
        var result = User.CreateUser("TestName", "TestSurname", "");
        Assert.False(result.IsSuccessed);
        Assert.Equal<string>(result.Messages.First(), "Email cannot be empty!");
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
