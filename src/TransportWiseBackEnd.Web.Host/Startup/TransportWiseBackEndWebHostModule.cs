using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TransportWiseBackEnd.Configuration;

namespace TransportWiseBackEnd.Web.Host.Startup
{
    [DependsOn(
       typeof(TransportWiseBackEndWebCoreModule))]
    public class TransportWiseBackEndWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TransportWiseBackEndWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TransportWiseBackEndWebHostModule).GetAssembly());
        }
    }
}
