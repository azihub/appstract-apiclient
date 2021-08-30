using BasicApiServices;
using BasicApiServices.Endpoints.WeatherForecasts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicApiServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {
        }

        //[Authorize]
        [HttpPost]
        public WeatherForecastResponse Get(WeatherForecastRequest request)
        {
            var weatherForecast = WeatherServices.GetWeatherForcast(request);
            return weatherForecast;
        }
    }
}
