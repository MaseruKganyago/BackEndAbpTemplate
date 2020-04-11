using System.Threading.Tasks;
using Abp.Application.Services;
using TransportWiseBackEnd.Authorization.Accounts.Dto;

namespace TransportWiseBackEnd.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
