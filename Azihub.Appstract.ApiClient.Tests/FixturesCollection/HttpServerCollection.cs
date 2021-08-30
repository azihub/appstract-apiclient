using Azihub.Appstract.ApiClient.Tests.TestServerFixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Azihub.Appstract.ApiClient.Tests.FixturesCollection
{
    [CollectionDefinition(ServerTypes.HttpServer)]
    public class HttpServerCollection : ICollectionFixture<HttpServerFixture>
    {
    }
}
