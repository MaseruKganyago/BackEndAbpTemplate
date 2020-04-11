using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TransportWiseBackEnd.Roles.Dto;
using TransportWiseBackEnd.Users.Dto;

namespace TransportWiseBackEnd.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
