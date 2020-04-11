using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TransportWiseBackEnd.Controllers
{
    public abstract class TransportWiseBackEndControllerBase: AbpController
    {
        protected TransportWiseBackEndControllerBase()
        {
            LocalizationSourceName = TransportWiseBackEndConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
