using Azihub.Appstract.ApiClient.Tests.BasicApiClientLibrary.Endpoints.WeatherForecasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azihub.Appstract.ApiClient.Tests.BasicApiClientLibrary.Endpoints
{
    public interface IEndpoints
    {
        WeatherForecastResponse GetWeatherForcast(WeatherForecastRequest request);
    }
}
