using BasicApiServices.Endpoints.WeatherForecasts;
using BasicApiServices.Endpoints.WeatherForecasts.Properties;
using System;
using System.Linq;

namespace BasicApiServices
{
    public class WeatherServices
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static WeatherForecastResponse GetWeatherForcast(WeatherForecastRequest request)
        {
            var rng = new Random();
            
            var randomWeather = Enumerable.Range(1, request.RequestCount).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return new WeatherForecastResponse(randomWeather);
        }
    }
}
