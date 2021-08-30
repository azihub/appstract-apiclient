using Azihub.Appstract.ApiClient.Tests.BasicApiClientLibrary;
using Azihub.Appstract.ApiClient.Tests.BasicApiClientLibrary.Endpoints.WeatherForecasts;
using Azihub.Appstract.ApiClient.Tests.FixturesCollection;
using Azihub.Appstract.ApiClient.Tests.TestServerFixtures;
using Azihub.Utilities.Base.Tests;
using System;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace Azihub.Appstract.ApiClient.Tests
{
    [Collection(ServerTypes.HttpServer)]
    public class HttpClientApiTests : TestBase
    {
        private readonly Uri _baseAddress;
        private readonly HttpClient _httpClient;

        public HttpClientApiTests(HttpServerFixture testServerFixture, ITestOutputHelper output) : base(output)
        {
            _baseAddress = testServerFixture.HttpClient.BaseAddress;
            _httpClient = testServerFixture.HttpClient;
        }
        
        [Fact]
        public void HttpWeatherClientTest()
        {
            BasicApiClient apiClient = new(_baseAddress, _httpClient);
            var rng = new Random();
            uint randomQty = (uint)rng.Next(1, 10);
            WeatherForecastRequest request = new(randomQty);
            
            // Action
            WeatherForecastResponse response = apiClient.GetWeatherForcast(request);

            Output.WriteLine($"Requested: {randomQty} and received response:" + response.DataSuccess.WeatherList.ToString());
            Assert.True(response.DataSuccess.WeatherList.Length > 0);
        }
    }
}
