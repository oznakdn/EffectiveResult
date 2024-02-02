namespace EffectiveResultTests;

public class ResultTests
{
    [Fact]
    public void ChangeEmail_When_ParameterInvalid_Should_Return_Failed()
    {
        var result = User.ChangeEmail("");
        Assert.False(result.IsSuccess);
        Assert.Equal("Email cannot be empty!",result.Message);
        Assert.NotNull(result.Message);
        Assert.Null(result.Messages);
    }

    [Fact]
    public void ChangeEmail_When_ParameterIsValid_Should_Return_Successed()
    {
        var result = User.ChangeEmail("test@mail.com");
        Assert.True(result.IsSuccess);
        Assert.Null(result.Message);
        Assert.Null(result.Messages);

    }



    [Fact]
    public void CreateUser_When_ParameterInvalid_Should_Return_Failed()
    {
        var result = User.CreateUser("TestName", "TestSurname", "");
        Assert.False(result.IsSuccess);
        Assert.Equal("Email cannot be empty!",result.Messages.First());
        Assert.Null(result.Value);
    }


    [Fact]
    public void CreateUser_When_ParameterIsValid_Should_Return_Successed()
    {
        var result = User.CreateUser("TestName", "TestSurname", "test@mail.com");
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
    }


    [Fact]
    public void GetUsers_Should_Return_Successed()
    {
        var result = User.GetUsers();
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Values);
    }
}
