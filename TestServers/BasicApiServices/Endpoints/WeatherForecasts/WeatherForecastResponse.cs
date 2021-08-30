using BasicApiServices.Endpoints.WeatherForecasts.Properties;
using Newtonsoft.Json;

namespace BasicApiServices.Endpoints.WeatherForecasts
{
    public class WeatherForecastResponse
    {
        [JsonProperty("weather_list")]
        public WeatherForecast[] WeatherList;

        public WeatherForecastResponse(WeatherForecast[] weatherList)
        {
            WeatherList = weatherList;
        }
    }
}
