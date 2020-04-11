using Abp.Application.Services.Dto;

namespace TransportWiseBackEnd.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

