namespace BasicApiServer.Attributes
{
    public class ApiKeyNotSetError
    {
        public ApiKeyNotSetError()
        {
        }

        public readonly string Message = "API Key is missing.";
    }
}