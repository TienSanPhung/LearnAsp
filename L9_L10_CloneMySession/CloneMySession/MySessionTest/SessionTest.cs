using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MySessionTest;

public class SessionTest : IClassFixture<WebApplicationFactory<CloneMySession.Program>>
{
    private readonly HttpClient factory;

    public SessionTest(WebApplicationFactory<CloneMySession.Program> factory)
    {
        this.factory = factory.CreateClient();
    }

    [Fact]
    public async Task Call_TestSestionContainer_Return_Ok_Async()
    {
        var response = await factory.GetAsync("/Test/TestSestionContainer");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}