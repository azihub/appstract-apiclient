using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azihub.Appstract.ApiClient.Tests.TestServerFixtures
{
    public class GrpcServerFixture : IDisposable
    {
        #region Public properties
        public object GrpcChannel { get; }
        #endregion



#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
        void IDisposable.Dispose()
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
        {
            //_factory.Dispose();
        }
    }
}
