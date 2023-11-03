namespace EffectiveResultTests;

public class ResultTests
{
    [Fact]
    public void ChangeEmail_When_ParameterInvalid_Should_Return_Failed()
    {
        var result = User.ChangeEmail("");
        Assert.True(result.IsFailed);
        Assert.Equal<string>(result.Message, "Email cannot be empty!");
        Assert.NotEmpty(result.Message);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void ChangeEmail_When_ParameterIsValid_Should_Return_Successed()
    {
        var result = User.ChangeEmail("test@mail.com");
        Assert.True(result.IsSuccessed);
        Assert.Empty(result.Message);
        Assert.Empty(result.Errors);

    }
}
