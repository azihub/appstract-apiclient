
namespace BasicApiServices.Endpoints.WeatherForecasts
{
    public class WeatherForecastRequest
    {
        public WeatherForecastRequest(int requestCount)
        {
            RequestCount = requestCount;
        }

        public int RequestCount { get; internal set; }
    }
}
