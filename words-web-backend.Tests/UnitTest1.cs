namespace words_web_backend.Tests;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class WordsWebTests
{
    [Fact]
    public async Task TestNumberToText()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        double number = 123.45;
        var response = await client.GetAsync($"/numberToText/${number}");
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var responseObject = JsonSerializer.Deserialize<NumberToTextResponse>(responseContent);

        Assert.NotNull(responseObject);
        Assert.Equal("one hundred and twenty three dollars and forty five cents", responseObject.textValue);
    }

    [Fact]
    public async Task TestNumberToText2()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        double number = 100;
        var response = await client.GetAsync($"/numberToText/${number}");
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var responseObject = JsonSerializer.Deserialize<NumberToTextResponse>(responseContent);

        Assert.NotNull(responseObject);
        Assert.Equal("one hundred dollars", responseObject.textValue);
    }

    [Fact]
    public async Task TestNumberToText3()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        double number = 100000;
        var response = await client.GetAsync($"/numberToText/${number}");
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var responseObject = JsonSerializer.Deserialize<NumberToTextResponse>(responseContent);

        Assert.NotNull(responseObject);
        Assert.Equal("Number exceeds maximum of 9999", responseObject.errormsg);
    }

    public class NumberToTextResponse
    {
        public string textValue { get; set; }

        public string errormsg { get; set; }

    }
}
