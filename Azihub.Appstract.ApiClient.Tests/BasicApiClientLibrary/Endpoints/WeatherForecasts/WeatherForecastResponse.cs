using Azihub.Appstract.ApiClient.Tests.BasicApiClientLibrary.Endpoints.WeatherForecasts.Properties;
using Azihub.Appstract.ApiClient.Tests.BasicApiClientLibrary.Errors;
using Newtonsoft.Json;
using System.Net.Http;

namespace Azihub.Appstract.ApiClient.Tests.BasicApiClientLibrary.Endpoints.WeatherForecasts
{
    public class WeatherForecastResponse : HttpResponse<WeatherForecastList,GeneralError>, IHttpResponse<WeatherForecastList, GeneralError>
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
}
