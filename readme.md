## Appstract ApiClient

Simply Request/Response model in REST API or GrpcClient model,
`IResponse<TSuccess, TFail>` will define what should expect if 
Endpoint send response and `IResponse<TSuccess, TFail, TFailback>` happens 
when expected error response didn't match endpoint response.


REST Api Exampole:
```C#
public interface IEndpoints
{
    WeatherForecastResponse GetWeatherForcast(WeatherForecastRequest request);
}

public class WeatherForecastRequest
{
    public WeatherForecastRequest(uint requestCount)
    {
        RequestCount = requestCount;
    }
    public uint RequestCount { get; }
}

public class WeatherForecastResponse : HttpResponse<WeatherForecastList,GeneralError>
{

    public WeatherForecastResponse(WeatherForecastList dataSuccess, HttpRequestMessage request, HttpResponseMessage response) :
        base(dataSuccess, request, response)
    {
    }
    public WeatherForecastResponse(GeneralError dataFailed, HttpRequestMessage request, HttpResponseMessage response) :
        base(dataFailed, request, response)
    {
    }
}

public class GeneralError
{
    [JsonProperty("message")]
    public string Message { get; }
}
```

Usage
```C#
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
```