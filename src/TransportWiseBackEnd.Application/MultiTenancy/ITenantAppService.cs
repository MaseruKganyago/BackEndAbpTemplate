using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TransportWiseBackEnd.MultiTenancy.Dto;

namespace TransportWiseBackEnd.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

