
namespace Azihub.Appstract.ApiClient.Tests.BasicApiClientLibrary.Endpoints.WeatherForecasts
{
    public class WeatherForecastRequest
    {
        public WeatherForecastRequest(uint requestCount)
        {
            RequestCount = requestCount;
        }

        public uint RequestCount { get; }
    }
}
