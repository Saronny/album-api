
namespace Album.Api.Tests;

public class UnitTest1
{
    [Fact]
    public void GetGreeting_WithName_ReturnsGreeting()
    {
        var greetingService = new GreetingService();

        string greeting = greetingService.GetGreeting("Mike");

        Assert.Equal($"Hello Mike from {Dns.GetHostName()}", greeting);
    }

    [Theory]
    [InlineData(null, "Hello World")]
    [InlineData("", "Hello World")]
    [InlineData(" ", "Hello World")]

    public void GetGreeting_WithoutName_ReturnsGreeting(string name, string expectedGreeting)
    {
        var greetingService = new GreetingService();

        string greeting = greetingService.GetGreeting(name);

        Assert.Equal(expectedGreeting, greeting);
    }
}