using Azihub.Appstract.ApiClient.Exceptions;
using Azihub.Utilities.Base.Extensions.Object;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azihub.Appstract.ApiClient
{
    public abstract class ApiClientBase
    {
        protected ApiClientBase(Uri baseUrl, HttpClient httpClient)
        {
            BaseUrl = baseUrl;
            _httpClient = httpClient;
        }
        protected ApiClientBase(Uri baseUrl, double timeoutMs = 15000)
        {
            BaseUrl = baseUrl;
            TimeoutMs = timeoutMs;
            _httpClient = new HttpClient
            {
                BaseAddress = BaseUrl,
                Timeout = TimeSpan.FromMilliseconds(TimeoutMs)
            };
        }
        protected Dictionary<string, string> DefaultRequestHeaders { get; set; } = new Dictionary<string, string>();
        private double TimeoutMs { get; }

        private static Uri BaseUrl { get; set; }
        private readonly HttpClient _httpClient;

        protected TResponse SendJsonRequest<TResponse, TSuccess, TFailed>(HttpMethod method, object requestParams, string endpoint, SelectCase selectCase = SelectCase.PascalToSnakeCase)
            //Func<string, HttpRequestMessage, HttpResponseMessage, TResponse> returnData, 
            where TResponse : IHttpResponse<TSuccess, TFailed>
        {
            return SendJsonRequestAsync<TResponse, TSuccess, TFailed>(method, requestParams, endpoint, selectCase)
                                                            .GetAwaiter().GetResult();
        }

        protected async Task<TResponse> SendJsonRequestAsync<TResponse, TSuccess, TFailed>(HttpMethod method,
                                                                                           object requestParams,
                                                                                           string endpoint,
                                                                                           SelectCase selectCase = SelectCase.PascalToSnakeCase,
                                                                                           CancellationToken cToken = default)
            where TResponse : IHttpResponse<TSuccess, TFailed>
        {
            // Default Headers to the this call.
            foreach (KeyValuePair<string, string> pair in DefaultRequestHeaders)
                _httpClient.DefaultRequestHeaders.Add(pair.Key, pair.Value);

            HttpRequestMessage requestMessage;
            if (method == HttpMethod.Get)
            {
                string queryParams = requestParams.GetQueryString(selectCase);
                requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{endpoint}?{queryParams}");
            }
            else if (method == HttpMethod.Post)
            {
                requestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint);
                string postData = JsonConvert.SerializeObject(requestParams);
                StringContent requestContent = new StringContent(postData, Encoding.UTF8, "application/json");
                requestMessage.Content = requestContent;
            }
            else
                throw new InvalidOperationException("Unsupported HttpMethod: " + method);

            HttpResponseMessage responseMessage = await SendHttpRequestAsync(requestMessage, cToken);

            return MakeHttpResponse<TResponse, TSuccess, TFailed>(requestMessage, responseMessage);
        }

        protected TResponse MakeHttpResponse<TResponse, TSuccess, TFailed>(HttpRequestMessage request, HttpResponseMessage response)
             where TResponse : IHttpResponse<TSuccess, TFailed>
        {
            string bodyJson = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    TSuccess successData = JsonConvert.DeserializeObject<TSuccess>(bodyJson);
                    return (TResponse)Activator.CreateInstance(typeof(TResponse), successData, request, response);
                }

                TFailed failedData = ParseErrorJson<TFailed>(bodyJson);
                return (TResponse)Activator.CreateInstance(typeof(TResponse), failedData, request, response);
            }
            catch (JsonSerializationException ex)
            {
#if DEBUG
                Debugger.Log(1, "Error", ex.Message);
                Debugger.Break();
#endif
                try
                {
                    TFailed failedData = ParseErrorJson<TFailed>(bodyJson);
                    return (TResponse)Activator.CreateInstance(typeof(TResponse), failedData, request, response);
                }
                catch (JsonSerializationException)
                {
                    throw new BadServerResponseException(response, bodyJson);
                }
            }
        }

        private TFailed ParseErrorJson<TFailed>(string bodyJson)
        {
            return JsonConvert.DeserializeObject<TFailed>(bodyJson);
        }

        protected async Task<HttpResponseMessage> SendHttpRequestAsync(HttpRequestMessage requestMessage, CancellationToken cToken)
        {
            try
            {
                return await _httpClient.SendAsync(requestMessage, cToken);
            }
            catch (Exception ex)
            {
                throw new NetworkLayerException("Failed to connect to server", ex);
            }
        }
    }
}
