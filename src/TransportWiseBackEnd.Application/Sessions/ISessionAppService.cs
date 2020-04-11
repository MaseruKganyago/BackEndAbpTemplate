using System.Threading.Tasks;
using Abp.Application.Services;
using TransportWiseBackEnd.Sessions.Dto;

namespace TransportWiseBackEnd.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
