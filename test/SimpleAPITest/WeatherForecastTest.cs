using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace SimpleAPITest;

public class WeatherForecastTest 
{
    [Fact]
    public async void GetWeather_Returns_Okay_Result()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/weatherforecast");
        var data = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}