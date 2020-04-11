using System.Collections.Generic;

namespace TransportWiseBackEnd.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
