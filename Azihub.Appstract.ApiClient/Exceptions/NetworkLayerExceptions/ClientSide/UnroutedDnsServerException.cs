using System;
using System.Net;

namespace Azihub.Appstract.ApiClient.Exceptions.NetworkLayerExceptions.ClientSide
{
    /// <summary>
    /// Unable to route DNS server to resolve Host IP address.
    /// </summary>
    public class UnroutedDnsServerException : Exception
    {
        public UnroutedDnsServerException(IPAddress ipAddress)
        {
            IpAddress = ipAddress;
        }

        public IPAddress IpAddress { get; }
    }
}
