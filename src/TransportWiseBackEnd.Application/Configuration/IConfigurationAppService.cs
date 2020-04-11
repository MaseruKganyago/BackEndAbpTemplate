using System.Threading.Tasks;
using TransportWiseBackEnd.Configuration.Dto;

namespace TransportWiseBackEnd.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
