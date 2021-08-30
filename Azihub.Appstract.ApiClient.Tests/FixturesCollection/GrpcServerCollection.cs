using Azihub.Appstract.ApiClient.Tests.TestServerFixtures;
using Xunit;

namespace Azihub.Appstract.ApiClient.Tests.FixturesCollection
{
    [CollectionDefinition(ServerTypes.GrpcServer)]
    public class GrpcServerCollection : ICollectionFixture<GrpcServerFixture>
    {
    }
}
