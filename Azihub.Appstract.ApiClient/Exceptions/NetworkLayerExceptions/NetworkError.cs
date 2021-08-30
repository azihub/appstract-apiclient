using System;

namespace Azihub.Appstract.ApiClient.Exceptions
{
    public abstract class NetworkError
    {
        public NetworkError(string message, Exception exception)
        {
            Message = message;
            Exception = exception;
        }

        public string Message { get; }
        public Exception Exception { get; }
    }
}