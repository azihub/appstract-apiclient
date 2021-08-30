using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azihub.Appstract.ApiClient.Tests.BasicApiClientLibrary.Endpoints.WeatherForecasts.Properties
{
    public class WeatherForecastList
    {
        public WeatherForecastList(WeatherForecast[] weatherList)
        {
            WeatherList = weatherList;
        }
        [JsonProperty("weather_list")]
        public WeatherForecast[] WeatherList { get; }
    }
}
