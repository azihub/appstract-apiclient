using System;

namespace Azihub.Appstract.ApiClient.Exceptions
{
    public class NetworkLayerException : Exception
    {
        public NetworkLayerException(string message , Exception ex): base(message, ex)
        {

        }
    }
}
