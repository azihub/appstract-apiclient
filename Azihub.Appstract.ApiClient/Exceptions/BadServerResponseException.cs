using System;
using System.Net.Http;

namespace Azihub.Appstract.ApiClient.Exceptions
{
    /// <summary>
    /// Server response is not defined in TSuccess or TFailed model.
    /// Probably API server model was changed without a notice.
    /// </summary>
    public class BadServerResponseException : Exception
    {
        public readonly HttpResponseMessage ResponseMessage;
        public readonly string Body;

        public BadServerResponseException(HttpResponseMessage responseMessage, string body)
        {
            ResponseMessage = responseMessage;
            Body = body;
        }
    }
}