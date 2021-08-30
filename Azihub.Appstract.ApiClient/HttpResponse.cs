using System;
using System.Net.Http;

namespace Azihub.Appstract.ApiClient
{
    /// <summary>
    /// HttpResponse with Contract to define what to expect when it is successful and what 
    /// </summary>
    /// <typeparam name="TSuccess">Type of object to expect in case of successful result.</typeparam>
    /// <typeparam name="TFailed">Type of object to expect in case of error result.</typeparam>
    public class HttpResponse<TSuccess, TFailed> : IHttpResponse<TSuccess, TFailed>
    {
        [Obsolete("Please use MakeSuccess() and MakeFailed() methods", true)]
        public HttpResponse() { }

        public HttpResponse(TSuccess dataSuccess, HttpRequestMessage request, HttpResponseMessage response)
        {
            Success = true;
            Request = request;
            Response = response;
            Data = dataSuccess;
        }

        public HttpResponse(TFailed dataFailed, HttpRequestMessage request, HttpResponseMessage response)
        {
            Success = false;
            Request = request;
            Response = response;
            Data = dataFailed;
        }


        //protected abstract IHttpResponse<TSuccess, TFailed> MakeSuccess(TSuccess dataSuccess, HttpRequestMessage request, HttpResponseMessage response);
        //protected abstract IHttpResponse<TSuccess, TFailed> MakeFailed(TFailed dataFailed, HttpRequestMessage request, HttpResponseMessage response);

        public static HttpResponse<TSuccess, TFailed> MakeFailed<TResponse>(TFailed data, HttpRequestMessage request, HttpResponseMessage response)
            where TResponse : IHttpResponse<TSuccess, TFailed>
        {
            return new HttpResponse<TSuccess, TFailed>(data, request, response);
        }

        //public static IHttpResponse<TSuccess, TFailed> MakeFailed<TResponse>(TFailed data, HttpRequestMessage request, HttpResponseMessage response)
        //    where TResponse : IHttpResponse<TSuccess, TFailed>
        //{
        //    return new IHttpResponse<TSuccess, TFailed>(data, request, response);
        //}

        //public static IHttpResponse<TSuccess, TFailed> MakeFailedFromJson<TResponse>(string jsonTxt, HttpRequestMessage request, HttpResponseMessage response)
        //{
        //    TFailed failedData = JsonConvert.DeserializeObject<TFailed>(jsonTxt);
        //    return new HttpResponse<TSuccess, TFailed>(failedData, request, response);
        //}

        public bool Success { get; }
        public HttpRequestMessage Request { get; }
        public HttpResponseMessage Response { get; }
        public object Data { get; }

        public TSuccess DataSuccess
        {
            get
            {
                if (Success)
                    return (TSuccess)Data;
                throw new InvalidOperationException("When Request is failed, DataSuccess is available");
            }
        }

        public TFailed DataFailed
        {
            get
            {
                if (!Success)
                    return (TFailed)Data;
                throw new InvalidOperationException("When Request is successful, DataFailed is not available");
            }
        }
    }
}
