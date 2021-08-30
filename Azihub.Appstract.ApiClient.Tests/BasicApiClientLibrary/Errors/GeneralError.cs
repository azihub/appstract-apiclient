using Newtonsoft.Json;

namespace Azihub.Appstract.ApiClient.Tests.BasicApiClientLibrary.Errors
{
    public class GeneralError
    {
        [JsonProperty("message")]
        public string Message { get; }
    }
}
