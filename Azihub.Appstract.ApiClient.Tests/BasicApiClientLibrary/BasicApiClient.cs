using Azihub.Appstract.ApiClient.Tests.BasicApiClientLibrary.Endpoints;
using Azihub.Appstract.ApiClient.Tests.BasicApiClientLibrary.Endpoints.WeatherForecasts;
using Azihub.Appstract.ApiClient.Tests.BasicApiClientLibrary.Endpoints.WeatherForecasts.Properties;
using Azihub.Appstract.ApiClient.Tests.BasicApiClientLibrary.Errors;
using System;
using System.Net.Http;

namespace Azihub.Appstract.ApiClient.Tests.BasicApiClientLibrary
{
    public class BasicApiClient : ApiClientBase, IEndpoints
    {
        public BasicApiClient(Uri baseUrl, HttpClient httpClient) : base(baseUrl, httpClient)
        {
        }

        public WeatherForecastResponse GetWeatherForcast(WeatherForecastRequest request)
        {
            WeatherForecastResponse response = 
                SendJsonRequest<WeatherForecastResponse, WeatherForecastList, GeneralError> (HttpMethod.Post, request, "/weather-forecast");
            return response;
        }
    }
}
