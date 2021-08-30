using System;
using System.Collections.Generic;
using System.Text;

namespace Azihub.Appstract.ApiClient
{
    public interface IResponse<TSuccess, TFailed>
    {
        object Data { get; }
        bool Success { get; }
        TSuccess DataSuccess { get; }
        TFailed DataFailed { get; }
    }
}
