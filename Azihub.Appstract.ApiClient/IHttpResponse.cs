using Azihub.Appstract.ApiClient.Exceptions;
using Azihub.GlobalData.Base.Networking.MediaTypes;
using System.Net.Http;

namespace Azihub.Appstract.ApiClient
{
    public interface IHttpResponse<TSuccess, TFailed> : IResponse<TSuccess, TFailed>
        
    {
        HttpRequestMessage Request { get; }
        HttpResponseMessage Response { get; }
    }
}