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
    [Fact]
    public async Task Call_Set_And_Get_SessionValuesAsync_Return_Ok_Async()
    {
        string RandomValues = Guid.NewGuid().ToString();
        await factory.GetAsync($"/Test/SetSessionValue?key=TEST-KEY&value={RandomValues}");
        
        var response = await factory.GetAsync("/Test/GetSessionValue?key=TEST-KEY");
       
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(RandomValues,responseBody );
        
    }
}