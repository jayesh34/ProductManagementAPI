using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace API.Tests;

public class ProductApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ProductApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetProducts_WithoutToken_ShouldReturn401()
    {
        // Act
        var response = await _client.GetAsync("/api/v1/Products");

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}