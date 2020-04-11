using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TransportWiseBackEnd.Configuration.Dto;

namespace TransportWiseBackEnd.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TransportWiseBackEndAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
