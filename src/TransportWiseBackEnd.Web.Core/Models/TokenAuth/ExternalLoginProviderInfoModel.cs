using Abp.AutoMapper;
using TransportWiseBackEnd.Authentication.External;

namespace TransportWiseBackEnd.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
