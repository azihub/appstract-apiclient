using Newtonsoft.Json;

namespace BasicApiServices.Errors
{
    public class GeneralError
    {
        [JsonProperty("message")]
        public string Message { get; }
    }
}
