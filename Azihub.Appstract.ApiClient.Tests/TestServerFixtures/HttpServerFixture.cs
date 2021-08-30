using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Mvc.Testing;
using BasicApiServer;
using System.Net.Http;

namespace Azihub.Appstract.ApiClient.Tests.TestServerFixtures
{
    public class HttpServerFixture : IDisposable
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public readonly HttpClient HttpClient;

        public HttpServerFixture()
        {
            _factory = new WebApplicationFactory<Startup>();
            HttpClient = _factory.CreateDefaultClient();

        }

#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
        void IDisposable.Dispose()
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
        {
            _factory.Dispose();
        }
    }
}